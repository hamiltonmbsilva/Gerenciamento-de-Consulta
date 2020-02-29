<template>
  <div>
    <b-form v-if="show" @submit.prevent="salvar">
      <b-form-group
        id="input-group-2"
        label="Data da Consulta:"
        label-for="input-1"
      >
        <div>
          <b-form-datepicker
            id="example-datepicker"
            v-model="agendamento.DataConsulta"
            class="mb-2"
          >
          </b-form-datepicker>
        </div>
      </b-form-group>

      <b-form-group
        id="input-group-2"
        label="Nome do Procedimento:"
        label-for="input-2"
      >
        <b-form-input
          id="input-2"
          v-model="agendamento.NomeProcedimento"
          required
          placeholder="Digite o Nome do Procedimento"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="input-group-2"
        label="Horario da Consulta:"
        label-for="input-2"
      >
        <b-row class="my-1" v-for="type in types" :key="type">
          <b-col sm="12">
            <b-form-input :id="`type-${type}`" :type="type"></b-form-input>
          </b-col>
        </b-row>
      </b-form-group>

      <!-- <b-form-group id="input-group-2" label="Lista de Pacientes:" label-for="input-2">
            
          <b-form-select v-model="paciente" :options="options"  :select-size="10" required></b-form-select>
          <div class="mt-3">
            Paciente Selecionados:
            <strong>{{ paciente }}</strong>
          </div> 
            
      </b-form-group> -->

      <b-form-group id="listaPaciente" label="Paciente:" label-for="input-2">
        <b-form-select
          v-model="paciente"
          :options="options"
          :select-size="10"
          required
        ></b-form-select>
        <div class="mt-3">
          Paciente Selecionados:
          <strong>{{ paciente }}</strong>
        </div>
      </b-form-group>

      <br />
      <br />
      <label for="">
        <h2>Cadastrar Anaminese</h2>
      </label>
      <br />

      <b-form-group
        id="input-group-2"
        label="Sintomas declarados:"
        label-for="input-2"
      >
        <b-form-input
          id="input-2"
          v-model="agendamento.Anaminese.Sintoma"
          required
          placeholder="Digite o Sintoma relatado"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="input-group-2"
        label="Doenças Existentes:"
        label-for="input-2"
      >
        <b-form-input
          id="input-2"
          v-model="agendamento.Anaminese.DoencaExistente"
          required
          placeholder="Digite a doença exixstente"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="input-group-3"
        label="Partes do Corpos:"
        label-for="input-6"
      >
        <b-form-select
          id="input-6"
          v-model="agendamento.Anaminese.PartesCorpo"
          :options="partesCorpo"
          required
        ></b-form-select>
      </b-form-group>

      <b-button
        @click="salvar()"
        type="submit"
        variant="success"
        style="margin-right: 10px;"
        >Salvar</b-button
      >
    </b-form>
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
        Horario: "types",
        PacienteId: "" ,
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
      types: ["time"]
    };
  },

  mounted() {
    this.carregarSelect();
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
      var valores = String(this.paciente).split("-");
      this.agendamento.PacienteId = valores[0];

      AgendamentoService.salvar(this.agendamento)
        .then(() => {
          alert("Agendamento salvo com sucesso!");
          this.$router.replace({ path: "/agendamento" });
        })
        .catch(error => {
          alert("Erro ao salvar Agendamento!\n" + error);
        });
    }
  }
};
</script>
