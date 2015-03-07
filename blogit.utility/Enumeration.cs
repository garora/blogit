using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogit.utility
{
    public class Enumeration
    {

        public Enumeration()
        {
            //Todo Need to look if we can call all enumerations through class constructor
        }
    }

    public enum UserDetail
    {
        UserId = 1,
        FirstName = 2,
        LastName = 3,
    }

    public enum MenusDirection
    {
        Horizontal = 1,
        Vertical
    }

    public enum Section
    {
        Article = 1,
        News = 2,
        Videos = 3,
        Forum = 4,
        Attachment = 5,
        Job = 6
    }
    public enum ArticleStatus
    {
        All = 1,
        Enabled = 2,
        Disabled = 3,
        Approved = 4,
        NotApproved = 5,
        EnabledAndApproved = 6,
        DisabledOrNotApproved = 7
    }
    public enum NewsStatus
    {
        All = 1,
        Enabled = 2,
        Disabled = 3,
        Expired = 4,
        NotExpired = 5,
        EnabledAndNotExpired = 6,
        DisabledOrExpired = 7
    }
    public enum VideoStatus
    {
        All = 1,
        Enabled = 2,
        Disabled = 3,
        Expired = 4,
        NotExpired = 5,
        EnabledAndNotExpired = 6,
        DisabledOrExpired = 7
    }
    public enum JobStatus
    {
        All = 1,
        Enabled = 2,
        Disabled = 3,
        Expired = 4,
        NotExpired = 5,
        EnabledAndNotExpired = 6,
        DisabledOrExpired = 7,
    }
    public enum AttachmentStatus
    {
        All = 1,
        Approved = 2,
        NotApproved = 3
    }
    public enum Role
    {
        Regular = 1,
        Writer = 2,
        Editor = 3,
        LeadEditor = 4,
        Webmaster = 5,
        Admin = 6,
        SuperAdmin = 7,
        Manager = 8,
        Contributor = 9,
        Publisher = 10
    }
    public enum Permission
    {
        All = 1,
        ReadOnly = 2,
        ReadWrite = 3,
        ReadWriteEdit = 4,
        ReadWriteEditDelete = 5,
        ReadWriteEditDeleteApprove = 6,
        None = 7
    }
    public enum EnabledStatus
    {
        All = 0,
        Enabled = 1,
        Disabled = 2
    }

    public enum JunctionOperator
    {
        AND = 0,
        OR = 1
    }

    public enum ValueOperator
    {
        Equal = 0,
        NotEqual = 1,
        StartWith = 2,
        EndWith = 3,
        Contains = 4
    }
    public enum CommandNames
    {
        Delete = 1,
        Update = 2,
        Cancel = 3,
        Approve = 4,
        Reject = 5
    }

}
