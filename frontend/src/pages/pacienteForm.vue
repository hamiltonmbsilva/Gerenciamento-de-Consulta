<template>
  <div>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group id="input-group-2" label="Codigo:" label-for="input-1">
        <b-form-input
          id="input-1"
          v-model="form.Codigo"
          type="number"
          required
          placeholder="Digite o Codigo do paciente"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Seu Nome:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.Nome"
          required
          placeholder="Digite o seu Nome"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="CPF:" label-for="input-3">
        <b-form-input
          id="input-3"
          v-model="form.CPF"
          type="number"
          required
          placeholder="Digite o CPF"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Senha:" label-for="input-4">
        <b-form-input
          id="input-4"
          v-model="form.Senha"
          type="number"
          required
          placeholder="Digite a Senha"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Data de Nascimento:" label-for="input-5">
        <div>         
          <b-form-datepicker 
          id="example-datepicker" 
          v-model="form.DataDeNascimento" 
          class="mb-2">
          </b-form-datepicker>         
        </div> 
      </b-form-group>

      <b-form-group id="input-group-3" label="Planos:" label-for="input-6">
        <b-form-select
          id="input-6"
          v-model="form.Planos"
          :options="planos"
          required
        ></b-form-select>
      </b-form-group>
      

      <b-button
      @click="salvar()"     
      type="submit" 
      variant="success"
      style="margin-right: 10px;"
      >Salvar</b-button>

      <!-- <b-button 
      type="reset" 
      variant="danger"
      >Resertar</b-button> -->

    </b-form>
    <!-- <b-card class="mt-3" header="Form Data Result">
      <pre class="m-0">{{ form }}</pre>
    </b-card> -->
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
          Planos: null          
        },        
        planos: [{value: '' }, 'UNIMED', 'AMIL', 'SAUDE_SERVIDOR', 'BRADESCO', 'OUTROS'],
        show: true
      }
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
              this.$router.replace({ path: "/paciente" });
            });
          }else{
            alert("Não é possivel salvar um paciente com dados invalidos!");
          }
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
      }
    }
  }
</script>