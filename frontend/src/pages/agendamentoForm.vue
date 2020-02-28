<template>
  <div>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">

    <b-form-group id="input-group-2" label="Data da Consulta:" label-for="input-1">
        <div>         
          <b-form-datepicker 
          id="example-datepicker" 
          v-model="form.DataConsulta" 
          class="mb-2">
          </b-form-datepicker>         
        </div> 
      </b-form-group>

      <b-form-group id="input-group-2" label="Nome do Procedimento:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.NomeProcedimento"         
          required
          placeholder="Digite o Nome do Procedimento"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Horario da Consulta:" label-for="input-2">
        <b-row class="my-1" v-for="type in types" :key="type">            
            <b-col sm="12">
                <b-form-input :id="`type-${type}`" :type="type"></b-form-input>
            </b-col>
        </b-row>
      </b-form-group>
        <b-form-group id="input-group-2" label="Horario da Consulta:" label-for="input-2">
            <div>
                <b-form-select v-model="selected" :pacientes="pacientes"></b-form-select>            
                <div class="mt-3">Selected: <strong>{{ selected }}</strong></div>
            </div>
        </b-form-group>
        <br/>
        <br/>
        <br/>

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
    mounted() {
    this.totalRows = this.pacientes.length;
    PacienteService.listarPaciente()
      .then(resposta => {
        resposta.data.forEach(element => {          
         element.data;
         console.log(element);
        });
        
        this.pacientes = resposta.data;
      })
      .catch(resposta => {
        console.log(resposta);
      });
  },  
    data() {
      return {
          pacientes: [],
          form: {
          Codigo: '',
          Nome: '',
          CPF: '',
          Senha: '',
          DataDeNascimento: '',
          Planos: ''          
        },        
        planos: ['UNIMED', 'AMIL', 'SAUDE_SERVIDOR', 'BRADESCO', 'OUTROS'],
        show: true,
        types: [          
          'time'         
        ],
         selected: null,
        options: [
          
        ]
      }
    }
  }
</script>
