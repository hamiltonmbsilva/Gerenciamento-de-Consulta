using Repository.Models;
using Repository.Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Utilidades;

namespace WebApi.Service
{
    public class PacienteService
    {
        private PacienteRepository repository = new PacienteRepository();


        public IEnumerable<Paciente> BuscarTodosOsPacinetes()
        {
            try
            {
                return repository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Paciente SalvarPaciente(Paciente paciente)
        {
            try
            {
                if (paciente == null)
                    throw new Exception("Não é possivel salvar um Paciente vazio");

                //Vendo se a idade do paciente e maior que 18
                int idade = DateTime.Now.Year - paciente.DataDeNascimento.Year;
                if (paciente.DataDeNascimento.AddYears(18) > DateTime.Now )
                {
                    idade = idade - 1;
                }

                //Chamando a classe ValidaCpf, passando uma string digitada pelo usuario
                bool valido =  ValidarCpf.IsCpf(paciente.CPF);


                if (idade > 18 && paciente.Codigo != 0 && valido == true)
                {
                    //Verificando se existe algum codigo cadastrado no banco de dados
                    var codigo = repository.Get(x => x.Codigo == paciente.Codigo).FirstOrDefault();

                    //Verificando se existe algum cpf cadastrado no banco de dados
                    var cpf = repository.Get(x => x.CPF == paciente.CPF).FirstOrDefault();                    

                    if (codigo != null)
                    {
                        throw new Exception("Não é possivel salvar o Paciente com um código duplicado!");
                    }
                    else if (cpf != null)
                    {
                        throw new Exception("Não é possivel salvar o Paciente com um CPF duplicado!");
                    }
                    else
                    {
                        //paciente.DataDeNascimento = Convert.ToDateTime(paciente.DataDeNascimento.ToString("dd/MM/yyyy"));
                        repository.Save(paciente);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Paciente AlterarPaciente(Paciente p)
        {
            try
            {
                if(p == null)
                {
                    throw new Exception("Não é possivel alterar o Paciente vazio");
                }
                else if(p.IdPaciente != 0)
                {
                    //mantendo o Paciente na memoria, sem necessidade de buscar no banco
                    var guardarPaciente = repository.Find(p.IdPaciente);

                    //Vendo se exixte algum Paciente com codigo igual no sistema
                    if(p.Codigo != guardarPaciente.Codigo)
                    {
                        var codigo = repository.Get(x => x.Codigo == p.Codigo).FirstOrDefault();
                        if(codigo != null)
                        {
                            throw new Exception("Não e possivel alterar o paciente com o Codigo Duplicado");
                        }
                    }

                    //Vendo se exixte algum Paciente com codigo igual no sistema
                    else if(p.CPF != guardarPaciente.CPF)
                    {
                        var cpf = repository.Get(x => x.CPF == p.CPF).FirstOrDefault();
                        if(cpf != null)
                        {
                            throw new Exception("Não e possivel alterar o paciente com o CPF Duplicado");
                        }
                    }

                    else
                    {
                        repository.UpdatePaciente(p);
                        return p;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirProduto(int? id)
        {
            try
            {
                if(id != null)
                {
                    var agRepository = new AgendamentoRepository();

                    var paciente = repository.Find(id);

                    if(paciente != null)
                    {
                        repository.Delete(x => x.IdPaciente == id);
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

        public Paciente BuscarPeloCodInterno(int cod)
        {
            try
            {
                if (cod != 0)
                {
                   return repository.Get(x => x.Codigo == cod).FirstOrDefault();
                }

                return new Paciente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Paciente BuscarPeloId(int id)
        {
            try
            {
                if (id != 0)
                {
                    return repository.Find(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            
        }


    }
}