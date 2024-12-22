using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            ContentCreatedByNavigations = new HashSet<Content>();
            ContentDeletedByNavigations = new HashSet<Content>();
            ContentUpdatedByNavigations = new HashSet<Content>();
            FileCreatedByNavigations = new HashSet<File>();
            FileDeletedByNavigations = new HashSet<File>();
            FileUpdatedByNavigations = new HashSet<File>();
            MediumCreatedByNavigations = new HashSet<Medium>();
            MediumDeletedByNavigations = new HashSet<Medium>();
            MediumUpdatedByNavigations = new HashSet<Medium>();
            MessagesUserDeletedByNavigations = new HashSet<MessagesUser>();
            MessagesUserUsers = new HashSet<MessagesUser>();
            MyRatings = new HashSet<MyRating>();
            PaymentUsers = new HashSet<PaymentUser>();
            RoomCreators = new HashSet<Room>();
            RoomDeletedByNavigations = new HashSet<Room>();
            RoomsUsers = new HashSet<RoomsUser>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Content> ContentCreatedByNavigations { get; set; }
        public virtual ICollection<Content> ContentDeletedByNavigations { get; set; }
        public virtual ICollection<Content> ContentUpdatedByNavigations { get; set; }
        public virtual ICollection<File> FileCreatedByNavigations { get; set; }
        public virtual ICollection<File> FileDeletedByNavigations { get; set; }
        public virtual ICollection<File> FileUpdatedByNavigations { get; set; }
        public virtual ICollection<Medium> MediumCreatedByNavigations { get; set; }
        public virtual ICollection<Medium> MediumDeletedByNavigations { get; set; }
        public virtual ICollection<Medium> MediumUpdatedByNavigations { get; set; }
        public virtual ICollection<MessagesUser> MessagesUserDeletedByNavigations { get; set; }
        public virtual ICollection<MessagesUser> MessagesUserUsers { get; set; }
        public virtual ICollection<MyRating> MyRatings { get; set; }
        public virtual ICollection<PaymentUser> PaymentUsers { get; set; }
        public virtual ICollection<Room> RoomCreators { get; set; }
        public virtual ICollection<Room> RoomDeletedByNavigations { get; set; }
        public virtual ICollection<RoomsUser> RoomsUsers { get; set; }
    }
}
