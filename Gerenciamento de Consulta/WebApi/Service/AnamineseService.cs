
using Repository.Models;
using RepositoryWebApi.Repository.EntityRepository;
using System;
using System.Collections.Generic;

namespace WebApi.Service
{
    public class AnamineseService
    {
        private AnamineseRepository repository = new AnamineseRepository();

        public IEnumerable<Anaminese> BuscarTodasAnaminese()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Anaminese SalvarAnaminese(Anaminese anamineses)
        {
            try
            {
                if (anamineses == null)
                {
                    throw new Exception("Não é possivel salvar uma Anaminese vazia!");
                }
                else
                {
                    repository.Save(anamineses);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Anaminese AlterarAnaminese(Anaminese a)
        {
            try
            {
                if (a == null)
                {
                    throw new Exception("Não é possivel alterar a Anaminese vazia");
                }
                else if (a.IdAnaminese != 0)
                {  
                        repository.UpdateAnaminese(a);
                        return a;
                   
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirAnaminese(int? id)
        {
            try
            {
                if (id != null)
                {
                    var aRepository = new AnamineseRepository();

                    var anaminese = repository.Find(id);

                    if (anaminese != null)
                    {
                        repository.Delete(x => x.IdAnaminese == id);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}