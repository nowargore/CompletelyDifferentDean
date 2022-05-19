using CompletelyDifferentDean.Model;
using System.Linq.Expressions;

namespace CompletelyDifferentDean.Database.Expressions;

public static class DisciplineExpression
{
    public static Expression<Func<Discipline, bool>> Id(int id)
    {
        return discipline => discipline.Id == id;
    }
}
