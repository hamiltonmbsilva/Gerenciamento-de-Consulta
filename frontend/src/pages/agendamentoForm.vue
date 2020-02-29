<template>
 <div class="container register-form" v-if="show" @submit.prevent="salvar">
            <div class="form form-redondamento">
                <div class="note">
                    <p>Cadastro de Agendamento</p>
                </div>

                <div class="form-content">
                    <div class="row">
                        <div class="col-md-6">

                          <div class="form-group">         
                                <b-form-datepicker class="form-control" placeholder="Digite a data da Consulta"
                                id="example-datepicker" 
                                v-model="agendamento.DataConsulta" 
                                >
                                </b-form-datepicker>         
                            </div> 

                            <div class="form-group">
                                <b-form-input class="form-control" 
                                  id="input-2"
                                  v-model="horario"
                                  v-mask="'##:##'"
                                  required
                                  placeholder="Digite o Horario da Consulta"
                                ></b-form-input>
                                <p v-if="erroHorario" style="color:red">{{erroHorario}}</p>
                            </div>  

                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Digite o Nome do Procedimento" v-model="agendamento.NomeProcedimento" required/>
                            </div>
                                                       
                        </div>

                        <div class="col-md-6">                            

                            <div class="form-group" label="Lista de Pacientes:">
                                <b-form-select class="form-control" v-model="paciente" :options="options" :select-size="7" required></b-form-select>
                                  <div class="mt-3">
                                    Paciente Selecionados:
                                    <strong>{{ paciente }}</strong>
                                  </div>
                            </div>
                         
                        </div>
                    </div>
                </div>  

                    <div class="note">
                      <p>Cadastrar Anaminese</p>
                    </div>

                  <div class="form-content">
                      <div class="row">
                          <div class="col-md-6">

                            <div class="form-group">         
                                  <div class="form-group">
                                    <input type="text" class="form-control" placeholder="Digite as Sintomas" v-model="agendamento.Anaminese.Sintoma" required/>
                                  </div>       
                              </div> 

                              <div class="form-group">
                                <label class="textoParteCorpo">Escolha uma parte do Corpo</label>
                                <b-form-select class="form-control"
                                    id="input-6"
                                    v-model="agendamento.Anaminese.PartesCorpo"
                                    :options="partesCorpo"
                                    required
                                  ></b-form-select>
                              </div>                  
                          </div>

                          <div class="col-md-6">
                              <div class="form-group">
                                  <input type="text" class="form-control" placeholder="Digite as Doenças Existentes" v-model="agendamento.Anaminese.DoencaExistente" required/>
                              </div>
                          </div>
                      </div>                    
                  </div>
              <button type="submit" class="btnSubmitAgendamento" @click="salvar()" variant="success">Salvar</button>
        </div>
    </div>
</template>

<script>
import PacienteService from "../Service/pacienteService";
import AgendamentoService from "../Service/agendamentoService";

export default {
  data() {
    return {
      options: [],
      paciente: [],

      agendamento: {
        DataConsulta: "",
        NomeProcedimento: "",
        Horario: "",
        PacienteId: "",
        Anaminese: {
          Sintoma: "",
          DoencaExistente: "",
          ParteCorpo: ""
        }
      },

      partesCorpo: [
        "Cabeça",
        "Abdomem",
        "Membros_Superiores",
        "Mebros_Inferiores"
      ],

      show: true,
      horario: "",
      erroHorario: ""
    };
  },

  mounted() {
    this.carregarSelect();
  },

  watch: {
    horario() {
      this.Verifica_Hora();
    }
  },

  methods: {
    onReset(evt) {
      evt.preventDefault();
      this.paciente = [];
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },

    carregarSelect() {
      PacienteService.listarPaciente()
        .then(resposta => {
          var pac = [];
          //debugger;

          resposta.data.forEach(element => {
            pac.push(element.Id + "-" + element.Nome);
          });
          this.options = pac;
          console.log(this.options);
        })
        .catch(resposta => {
          console.log(resposta);
        });
    },

    salvar() {
      if (this.erroHorario) {
        this.horario.focus();
        return;
      }

      this.agendamento.Horario = this.horario;

      var valores = String(this.paciente).split("-");
      this.agendamento.PacienteId = valores[0];

      AgendamentoService.salvar(this.agendamento)
        .then(() => {
          alert("Agendamento salvo com sucesso!");
          this.$router.replace({ path: "/agendamentos" });
        })
        .catch(error => {
          alert("Erro ao salvar Agendamento!\n" + error);
        });
    },

    Verifica_Hora() {
      var hrs = this.horario.substring(0, 2);
      var min = this.horario.substring(3, 5);

      var estado = "";
      if (hrs < 0 || hrs > 23 || min < 0 || min > 59) {
        estado = "errada";
      }

      if (this.horario == "") {
        estado = "errada";
      }
      if (estado == "errada") {
        this.erroHorario = "Hora invalida!";
        this.horario.focus();
      } else {
        this.erroHorario = "";
      }
    }
  }
};
</script>

<style>
.form
{  
  border: 2px solid #ccc;
  border-radius:10px !important;
  font-family: Arial, Helvetica, sans-serif;
}
  .note
{
    text-align: center;
    font-size: 25px;
    font-family: Arial, Helvetica, sans-serif;
    height: 80px;
    background: -webkit-linear-gradient(left, #0072ff, #8811c5);
    color: #fff;
    font-weight: bold;
    line-height: 80px;
    border: 2px solid #ccc;
    border-radius:10px !important;
}
.form-content
{
    padding: 5%;
    border: 0px solid #ced4da;
    margin-bottom: 2%;
}
.form-control{
    font-family: Arial, Helvetica, sans-serif;
    border-radius:1.5rem;
}
.btnSubmitAgendamento
{
    border:none;
    border-radius:1.5rem;
    padding: 1%;
    width: 20%;
    cursor: pointer;
    background: #0062cc;
    color: #fff;    
    margin-bottom: 20px;
    font-family: Arial, Helvetica, sans-serif;
}
.textoParteCorpo{
  font-family: Arial, Helvetica, sans-serif;
  color: #000000;
  font-size: 16px;
}
</style>
