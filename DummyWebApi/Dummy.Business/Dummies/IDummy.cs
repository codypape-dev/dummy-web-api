using System.Collections.Generic;

namespace Dummy.Business.Dummies
{
    public interface IDummy
    {
        Model.Dummy Create(Model.Dummy dummy);
        List<Model.Dummy> GetDummies();
        Model.Dummy GetDummyById(string id);
        Model.Dummy UpdateById(Model.Dummy dummy);
        bool DeleteDummyById(string id);
    }
}
