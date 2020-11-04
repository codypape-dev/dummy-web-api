using System.Collections.Generic;

namespace Dummy.DataAccess.Repository
{
    public interface IDummiesRepository
    {
        Model.Dummy Create(Model.Dummy dummy);
        List<Model.Dummy> GetDummies();
        Model.Dummy GetDummyById(string id);
        Model.Dummy UpdateById(Model.Dummy dummy);
        bool Delete(string id);
    }
}
