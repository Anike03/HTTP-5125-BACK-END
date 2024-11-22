using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolDatabase.Models;
namespace SchoolDatabase.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of all teachers in the system.
        /// </summary>
        /// <example>
        /// GET api/Teacher/ListTeachers -> [{"teacherId":1,"teacherFName":"Alexander","teacherLName":"Bennett","employeeNumber":"T378","hireDate":"2016-08-05 00:00:00","salary":55.30,"coursesByTeacher":[{"courseId":1,"courseCode":"http5101","teacherId":1,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Web Application Development"}]},{"teacherId":2,"teacherFName":"Caitlin","teacherLName":"Cummings","employeeNumber":"T381","hireDate":"2014-06-10 00:00:00","salary":62.77,"coursesByTeacher":[{"courseId":2,"courseCode":"http5102","teacherId":2,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Project Management"},{"courseId":6,"courseCode":"http5201","teacherId":2,"startDate":"2019-01-08","finishDate":"2019-04-27","courseName":"Security & Quality Assurance"}]},..]
        /// </example>
        /// <returns>
        /// A list of teacher objects.
        /// </returns>
        [HttpGet]
        [Route(template: "ListTeachers")]
        public List<Teacher> ListTeachers()
        {
            // Initialize an empty list to store teacher details
            List<Teacher> Teachers = new List<Teacher>();

            // Ensure the database connection is closed after the execution
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                // Open the connection to the database
                Connection.Open();

                // Create a command object to execute the query
                MySqlCommand Command = Connection.CreateCommand();

                // Define the SQL query to fetch all teachers
                Command.CommandText = "SELECT * FROM teachers";

                // Execute the query and store the result set
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    // Process each record in the result set
                    while (ResultSet.Read())
                    {
                        Teacher CurrentTeacher = new Teacher();
                        List<Course> Courses = new List<Course>();

                        // Extract column values based on column names
                        CurrentTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        CurrentTeacher.TeacherFName = ResultSet["teacherfname"].ToString();
                        CurrentTeacher.TeacherLName = ResultSet["teacherlname"].ToString();
                        CurrentTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                        CurrentTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]).ToString("yyyy/MM/dd HH:mm:ss");
                        CurrentTeacher.Salary = Convert.ToDecimal(ResultSet["salary"]);

                        // Match courses taught by the teacher
                        foreach (Course CourseDetails in ListCourses())
                        {
                            if (CurrentTeacher.TeacherId == CourseDetails.TeacherId)
                            {
                                Courses.Add(CourseDetails);
                            }
                        }
                        CurrentTeacher.CoursesByTeacher = Courses;

                        // Add the teacher to the list
                        Teachers.Add(CurrentTeacher);
                    }
                }
            }

            // Return the list of teachers
            return Teachers;
        }

        /// <summary>
        /// Retrieves a list of all courses in the system.
        /// </summary>
        /// <example>
        /// GET api/Course/ListCourses -> [{"courseId":1,"courseCode":"http5101","teacherId":1,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Web Application Development"},{"courseId":2,"courseCode":"http5102","teacherId":2,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Project Management"},{"courseId":3,"courseCode":"http5103","teacherId":5,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Web Programming"},..]
        /// </example>
        /// <returns>
        /// A list of course objects.
        /// </returns>
        [HttpGet]
        [Route(template: "ListCourses")]
        public List<Course> ListCourses()
        {
            // Initialize an empty list to store course details
            List<Course> Courses = new List<Course>();

            // Ensure the database connection is closed after the execution
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                // Open the connection to the database
                Connection.Open();

                // Create a command object to execute the query
                MySqlCommand Command = Connection.CreateCommand();

                // Define the SQL query to fetch all courses
                Command.CommandText = "SELECT * FROM courses";

                // Execute the query and store the result set
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    // Process each record in the result set
                    while (ResultSet.Read())
                    {
                        Course CurrentCourse = new Course();

                        // Extract column values based on column names
                        CurrentCourse.CourseId = Convert.ToInt32(ResultSet["courseid"]);
                        CurrentCourse.CourseCode = (ResultSet["coursecode"]).ToString();
                        CurrentCourse.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        CurrentCourse.StartDate = Convert.ToDateTime(ResultSet["startdate"]).ToString("yyyy-MM-dd");
                        CurrentCourse.FinishDate = Convert.ToDateTime(ResultSet["finishdate"]).ToString("yyyy-MM-dd");
                        CurrentCourse.CourseName = (ResultSet["coursename"]).ToString();

                        // Add the course to the list
                        Courses.Add(CurrentCourse);
                    }
                }
            }

            // Return the list of courses
            return Courses;
        }

        /// <summary>
        /// Fetches details of a specific teacher by their ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to retrieve.</param>
        /// <example>
        /// GET api/Teacher/FindTeacher/7 -> {"teacherId":7,"teacherFName":"Shannon","teacherLName":"Barton","employeeNumber":"T397","hireDate":"2013-08-04 00:00:00","salary":64.70,"coursesByTeacher":[{"courseId":4,"courseCode":"http5104","teacherId":7,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Digital Design"}]}
        /// </example>
        /// <returns>
        /// The teacher object matching the given ID or an empty object if not found.
        /// </returns>
        [HttpGet]
        [Route(template: "FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            // Initialize an empty teacher object
            Teacher SelectedTeacher = new Teacher();
            List<Course> Courses = new List<Course>();

            // Ensure the database connection is closed after the execution
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                // Open the connection to the database
                Connection.Open();

                // Create a command object to execute the query
                MySqlCommand Command = Connection.CreateCommand();

                // Define the SQL query to fetch the teacher by ID
                Command.CommandText = "SELECT * FROM teachers WHERE teacherid=@id";
                Command.Parameters.AddWithValue("@id", id);

                // Execute the query and store the result set
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    // Process each record in the result set
                    while (ResultSet.Read())
                    {
                        // Extract column values based on column names
                        SelectedTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        SelectedTeacher.TeacherFName = ResultSet["teacherfname"].ToString();
                        SelectedTeacher.TeacherLName = ResultSet["teacherlname"].ToString();
                        SelectedTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                        SelectedTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]).ToString("yyyy/MM/dd HH:mm:ss");
                        SelectedTeacher.Salary = Convert.ToDecimal(ResultSet["salary"]);

                        // Match courses taught by the teacher
                        foreach (Course CourseDetails in ListCourses())
                        {
                            if (SelectedTeacher.TeacherId == CourseDetails.TeacherId)
                            {
                                Courses.Add(CourseDetails);
                            }
                        }
                        SelectedTeacher.CoursesByTeacher = Courses;
                    }
                }
            }

            // Return the teacher object
            return SelectedTeacher;
        }
    }
}
