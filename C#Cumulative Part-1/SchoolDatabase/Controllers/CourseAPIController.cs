using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolDatabase.Models;
namespace SchoolDatabase.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class CourseAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        // Inject the school database context into the controller
        public CourseAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Fetches a list of all courses in the database.
        /// </summary>
        /// <example>
        /// GET api/Course/ListCourses -> [{"courseId":1,"courseCode":"http5101","teacherId":1,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Web Application Development"},{"courseId":2,"courseCode":"http5102","teacherId":2,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Project Management"},{"courseId":3,"courseCode":"http5103","teacherId":5,"startDate":"2018-09-04","finishDate":"2018-12-14","courseName":"Web Programming"},..]
        /// </example>
        /// <returns>
        /// A list containing details of all courses.
        /// </returns>
        [HttpGet]
        [Route(template: "ListCourses")]
        public List<Course> ListCourses()
        {
            // Initialize an empty list to store course information
            List<Course> Courses = new List<Course>();

            // Use 'using' to ensure the database connection is closed after execution
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                // Establish a connection to the database
                Connection.Open();

                // Create a new database command for the query
                MySqlCommand Command = Connection.CreateCommand();

                // Define the SQL query to retrieve all courses
                Command.CommandText = "SELECT * FROM courses";

                // Execute the query and store the results
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    // Process each row in the result set
                    while (ResultSet.Read())
                    {
                        Course CurrentCourse = new Course();
                        // Extract column data using the column name as a reference
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

            // Return the complete list of courses
            return Courses;
        }

        /// <summary>
        /// Fetches details of a specific course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course to be retrieved.</param>
        /// <example>
        /// GET api/Course/FindCourse/7 -> {"courseId":7,"courseCode":"http5202","teacherId":3,"startDate":"2019-01-08","finishDate":"2019-04-27","courseName":"Web Application Development 2"}
        /// </example>
        /// <returns>
        /// A course object matching the given ID or an empty object if no match is found.
        /// </returns>
        [HttpGet]
        [Route(template: "FindCourse/{id}")]
        public Course FindCourse(int id)
        {
            // Initialize an empty course object
            Course SelectedCourse = new Course();

            // Use 'using' to ensure the database connection is closed after execution
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                // Establish a connection to the database
                Connection.Open();

                // Create a new database command for the query
                MySqlCommand Command = Connection.CreateCommand();

                // Define the SQL query to retrieve a course by its ID
                Command.CommandText = "SELECT * FROM courses WHERE courseid=@id";
                Command.Parameters.AddWithValue("@id", id);

                // Execute the query and store the results
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    // Process each row in the result set
                    while (ResultSet.Read())
                    {
                        // Extract column data using the column name as a reference
                        SelectedCourse.CourseId = Convert.ToInt32(ResultSet["courseid"]);
                        SelectedCourse.CourseCode = (ResultSet["coursecode"]).ToString();
                        SelectedCourse.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        SelectedCourse.StartDate = Convert.ToDateTime(ResultSet["startdate"]).ToString("yyyy-MM-dd");
                        SelectedCourse.FinishDate = Convert.ToDateTime(ResultSet["finishdate"]).ToString("yyyy-MM-dd");
                        SelectedCourse.CourseName = (ResultSet["coursename"]).ToString();

                    }
                }
            }

            // Return the course object with the matching ID
            return SelectedCourse;
        }
    }
}
