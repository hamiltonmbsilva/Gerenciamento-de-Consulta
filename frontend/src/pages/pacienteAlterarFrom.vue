<template>
  <div class="container register-form" v-if="show">
      <div class="form form-redondamento">
                <div class="note">
                    <p>Alterar Paciente</p>
                </div>

                <div class="form-content">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="number" class="form-control"  v-model="form.Codigo" required />                                
                            </div>  

                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Digite o CPF do Paciente" v-model="form.CPF" required/>
                            </div>
                            
                              <div class="form-group">         
                                <b-form-datepicker class="form-control" placeholder="Digite a data Aniversario"
                                id="example-datepicker" 
                                v-model="form.DataDeNascimento" 
                                >
                                </b-form-datepicker>         
                              </div> 
                            
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Digite o Nome do Paciente" v-model="form.Nome" required/>
                            </div>

                            <div class="form-group">
                                <input type="password" class="form-control" placeholder="Digite a senha do Paciente" v-model="form.Senha" required/>
                            </div>

                            <div class="form-group">
                                <b-form-select class="form-control" placeholder="Escolha um Plano"
                                      id="input-6"  
                                      v-model="form.Planos"
                                      :options="planos"
                                      required
                                  ></b-form-select>
                            </div>
                        </div>
                    </div>
                    <button type="submit" class="btnAlterar" @click="voltar()" variant="success">Voltar</button>
                    <button type="submit" class="btnSubmit" @click="editar()" variant="success">Alterar</button>
                </div>
      </div>
  </div>
  
</template>

<script>

import PacienteService from "../Service/pacienteService";


  export default {
    data() {
      return {
        form: {
          Codigo: '',
          Nome: '',
          CPF: '',
          Senha: '',
          DataDeNascimento: '',
          Planos: ''          
        },        
        planos: ['UNIMED', 'AMIL', 'SAUDE_SERVIDOR', 'BRADESCO', 'OUTROS'],
        show: true
      }
    }, 
    
    mounted() {
        this.pegarusuario();
    },

    methods: {
      onSubmit(evt) {
        evt.preventDefault()
        alert(JSON.stringify(this.form))
      },
      onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.form.Codigo = ''
        this.form.Nome = ''
        this.form.CPF = ''
        this.form.Senha = ''
        this.form.DataDeNascimento= ''
        this.form.Planos = null        
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      },      

      pegarusuario(){
        this.IdPaciente = this.$route.query.id;
        
        PacienteService.buscarPacientePeloId(this.IdPaciente)
        .then(resposta => { 

            this.form.Codigo = resposta.data.Codigo;
            this.form.Nome = resposta.data.Nome;
            this.form.CPF = resposta.data.CPF;
            this.form.Senha = resposta.data.Senha;
            this.form.DataDeNascimento= this.organizarData(
            resposta.data.DataDeNascimento,
            true
          );
            
            //resposta.data.DataDeNascimento;
            //'UNIMED = 0', 'AMIL = 1', 'SAUDE_SERVIDOR = 2', 'BRADESCO = 3', 'OUTROS = 4'
                if(resposta.data.Planos == 0){
                    this.form.Planos = 'UNIMED';
                }
                else if(resposta.data.Planos == 1){
                this.form.Planos = 'AMIL';
                }
                else if(resposta.data.Planos == 2){
                this.form.Planos = 'SAUDE_SERVIDOR';
                }
                else if(resposta.data.Planos == 3){
                this.form.Planos = 'BRADESCO';
                }
                else if(resposta.data.Planos == 4){
                this.form.Planos = 'OUTROS';
                }

                this.form.IdPaciente = this.IdPaciente;
            //this.form.Planos = resposta.data.Planos; 
            // this.paciente = resposta.data;
            //console.log(resposta.data.DataDeNascimento);
        })
        .catch(resposta => {
            console.log(resposta);
        });
      },

      salvar(){
          if(this.validateCodigo() != null){

            //this.form.Planos = this.transformarEnum(this.form.Planos);

            PacienteService.salvar(this.form)
            .then(() => {
              alert("Paciente salvo com sucesso!");
              this.$router.replace({ path: "/paciente" });
            })
            .catch(error => {
              alert("Erro ao salvar paciente!\n" + error);              
            });
          }else{
            alert("Não é possivel salvar um paciente com dados invalidos!");
          }
      },

      editar(){
          PacienteService.alterarPaciente(this.form)
          .then(() => {
              alert("Paciente alterado com sucesso!");
              this.$router.replace({ path: "/paciente" });
            })
            .catch(error => {
              alert("Erro ao alterar paciente!\n" + error);
              this.$router.replace({ path: "/paciente/alterar?id=" + this.IdPaciente});
            });          
         },

      //Valida o valor no codigo interno
      validateCodigo() {
        if (this.form.Codigo < 0 || this.form.Codigo > 999999999999) {
          alert("Valor no código não é invalido!");
          return false;
        }
        return true;
      },

      transformarEnum(){
        //'UNIMED = 0', 'AMIL = 1', 'SAUDE_SERVIDOR = 2', 'BRADESCO = 3', 'OUTROS = 4'
        if(this.form.Planos == 'UNIMED'){
          this.form.Planos = 0;
        }
        else if(this.form.Planos == 'AMIL'){
          this.form.Planos = 1;
        }
        else if(this.form.Planos == 'SAUDE_SERVIDOR'){
          this.form.Planos = 2;
        }
        else if(this.form.Planos == 'BRADESCO'){
          this.form.Planos = 3;
        }
        else if(this.form.Planos == 'OUTROS'){
          this.form.Planos = 4;
        }
      },

      // metodo que organiza a data no formato desejado
        organizarData(d, isData) {
            var dataSplit = String(d).split("T");
            var data = dataSplit[0];
            var time = dataSplit[1];

            if (isData) {
                var ano = String(data).split("-")[0];
                var mes = String(data).split("-")[1];
                var dia = String(data).split("-")[2];

                return `${dia}/${mes}/${ano}`;
            } else {
                var hora = String(time).split(":")[0];
                var minuto = String(time).split(":")[1];

                return `${hora}:${minuto}`;
            }
        },

        voltar(){
            this.$router.replace({
          path: "/paciente"
      });
        }

    }
  }
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
.btnSubmit
{
    border:none;
    border-radius:1.5rem;
    padding: 1%;
    width: 20%;
    cursor: pointer;
    background: #0062cc;
    color: #fff;
    margin-top: 30px;
    font-family: Arial, Helvetica, sans-serif;
}
.btnAlterar{
    border:none;
    border-radius:1.5rem;
    padding: 1%;
    width: 20%;
    margin-right: 10px;
    cursor: pointer;
    background: #0062cc;
    color: #fff;
    margin-top: 30px;
    font-family: Arial, Helvetica, sans-serif;
}
</style>