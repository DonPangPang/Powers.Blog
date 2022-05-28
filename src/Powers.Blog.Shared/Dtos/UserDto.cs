using System;
using System.Collections.Generic;
using System.Text;

namespace Powers.Blog.Shared.Dtos
{
    public class UserDto
    {
        public string? Account { get; set; }

        public string? UserName { get; set; }

        public string? Description { get; set; }

        public string? Email { get; set; }

        public string? Url { get; set; }

        public string? Icon { get; set; }
    }
}