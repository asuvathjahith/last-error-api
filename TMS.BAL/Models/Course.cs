using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TMS.BAL
{
    public class Course
    {
        public Course()
        {
            User Trainer = new User();
            CourseStatus status= new CourseStatus();
            Department Department = new Department();
            List<Topic> Topics = new List<Topic>();
            List<User> Users = new List<User>();
            List<CourseFeedback> Feedbacks = new List<CourseFeedback>();
        }
        //model attribute
        [Required]
        public int Id { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        [NotMapped]
        public int TrainerId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        [RegularExpression(
            @"^([A-Za-z\s]{3}){0,20}$",
            ErrorMessage = "Enter a valid name for Course. Course name must not contain any special character or numbers"
         )]
        public string Name { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        [RegularExpression(
            @"^([A-Za-z\s0-9]){20,1000}$",
            ErrorMessage = "Enter a Valid Description"
         )]
        public string Description { get; set; }
        public bool? isDisabled { get; set; }
        
        //Audit fields
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        //Foreign key relation
        [NotMapped]
        public virtual User? Trainer { get; set; }
        public virtual Department? Department { get; set; }
        public virtual CourseStatus? Status { get; set; }
        public virtual List<Topic>? Topics { get; set; }
        public virtual List<User>? Users { get; set; }
        public virtual List<CourseFeedback>? Feedbacks { get; set; }
    }
}