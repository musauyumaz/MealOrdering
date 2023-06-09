﻿namespace MealOrdering.Application.Features.Users.DTOs
{
    public class ListUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }

    }
}
//Id = u.Id,
//                    FullName = $"{u.FirstName} {u.LastName}",
//                    Email = u.EmailAddress,
//                    CreatedAt = u.CreatedDate,
//                    Status = u.IsActive