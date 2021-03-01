using System;
using System.Collections.Generic;
using System.Text;

namespace Rzproekt.Models {
    public class MultepleContextTable {
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int HeaderId { get; set; }
        public HeaderDto Headers { get; set; }

        public int OrderId { get; set; }
        public OrderDto Orders { get; set; }

        public int AboutId { get; set; }
        public AboutDto Abouts { get; set; }

        public int StatisticId { get; set; }
        public StatisticDto Statistics { get; set; }

        public int ProjectId { get; set; }
        public ProjectDto Projects { get; set; }

        public int ClientId { get; set; }
        public ClientDto Clients { get; set; }

        public int ContactId { get; set; }
        public ContactCompanyDto Contacts { get; set; }

        public int FooterId { get; set; }
        public FooterDto Footers { get; set; }

        public int MessageId { get; set; }
        public MessageDto Messages { get; set; }

        public int CertId { get; set; }
        public CertDto Certs { get; set; }

        public int DetailId { get; set; }
        public ProjectDetailDto DetailProjects { get; set; }

        public int AwardId { get; set; }
        public AwardDto Awards { get; set; }

        public int ContactLead { get; set; }
        public ContactLeadDto ContactLeads { get; set; }

        public int DialogId { get; set; }
        public MainInfoDialog MainInfoDialogs { get; set; }

        public int DMessageId { get; set; }
        public DialogMessage DialogMessages { get; set; }

        public int DialogMemberId { get; set; }
        public DialogMember DialogMembers { get; set; }

        public int AnonymousUserId { get; set; }
        public AnonymousUserDto AnonymousUsers { get; set; }
    }
}
