namespace CompletelyDifferentDean.Model.Common;

public interface IAuditableEntity
{
    DateTime Created { get; }
    string CreatedBy { get; }
    DateTime LastModified { get; }
    string LastModifiedBy { get; }

    void WasCreated(DateTime created, string createdBy);
    void WasModified(DateTime modified, string modifiedBy);
}
