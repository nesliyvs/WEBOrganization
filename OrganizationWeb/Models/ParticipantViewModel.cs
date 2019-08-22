using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganizationWeb.Models
{
    public class ParticipantViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual List<Comment> Comment { get; set; }
        public virtual List<OrganizationParticipant> OrganizationParticipant { get; set; }
    }
}