using CompletelyDifferentDean.Model.Common;

namespace CompletelyDifferentDean.Model;

public class Discipline : IAuditableEntity
{
    public Discipline(string name, string description)
    {
        Name = name;
        Description = description;

        CreatedBy = "";
        LastModifiedBy = "";
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public DateTime Created { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime LastModified { get; private set; }
    public string LastModifiedBy { get; private set; }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void WasCreated(DateTime created, string createdBy)
    {
        Created = created;
        CreatedBy = createdBy;

        LastModified = created;
        LastModifiedBy = createdBy;
    }

    public void WasModified(DateTime modified, string modifiedBy)
    {
        LastModified = modified;
        LastModifiedBy = modifiedBy;
    }

}
