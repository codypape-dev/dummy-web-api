using Dummy.DataAccess.Repository;
using System.Collections.Generic;

namespace Dummy.Business.Dummies
{
    public class Dummy : IDummy
    {
        private readonly IDummiesRepository repository;

        public Dummy(IDummiesRepository repository)
        {
            this.repository = repository;
        }
        public Model.Dummy Create(Model.Dummy dummy)
        {
            return repository.Create(dummy);
        }

        public bool DeleteDummyById(string id)
        {
            return repository.Delete(id);
        }

        public List<Model.Dummy> GetDummies()
        {
            return repository.GetDummies();
        }

        public Model.Dummy GetDummyById(string id)
        {
            return repository.GetDummyById(id);
        }

        public Model.Dummy UpdateById(Model.Dummy dummy)
        {
            return repository.UpdateById(dummy);
        }
    }
}
