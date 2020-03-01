<template>
  <div class="container">
    <div>
      <Titulo texto="Listagem dos Agendamentos" />
    </div>
    <b-row>
      <b-col>
        <b-nav-form class="pesquisa">
          <b-form-datepicker v-model="filter" id="example-datepicker"  placeholder="Pesquisar por data do dia"></b-form-datepicker>
          <b-button variant="outline-success" :disabled="!filter" @click="filter = ''">Limpar</b-button>
        </b-nav-form>
      </b-col>
      <b-col>
        <router-link to="agendamentos/cadastrar">
          <b-button variant="outline-success" class="btn-cadastrar">Cadastrar Agendamentos</b-button>
        </router-link>
      </b-col>
    </b-row>

    
    <!-- Info modal -->
    <b-modal
      v-if="this.agendamento != null"
      :id="infoModal.id"
      :title="infoModal.title"
      ok-only
      @hide="resetInfoModal"
    >
      <p class="h6">{{fields[1].label +": "+ agendamento.NomeProcedimento}}</p>
      <p class="h6">{{fields[2].label +": "+ agendamento.Pacientes.Nome}}</p>
      <p class="h6">{{fields[3].label +": "+ agendamento.DataConsulta}}</p>      
      <p class="h6">{{fields[4].label +": "+ agendamento.Horario}}</p>
      <!-- <p class="h6">{{fields[5].label +": "+ agendamento.Anaminese.Sintoma}}</p>
      <p class="h6">{{fields[6].label +": "+ agendamento.Anaminese.DoencaExistente}}</p>
      <p class="h6">{{fields[7].label +": "+ agendamento.Anaminese.PartesCorpo}}</p> -->

      <b-button
        variant="outline-success"
        class="btn-alterar-agendamento mr-1"
        @click="alterar(agendamento, row.item, row.index, $event.target)"
      >Alterar</b-button>
      <b-button
        variant="outline-danger"
        class="btn-excluir-agendamento mr-1"
        @click="excluir(agendamento, row.item, row.index, $event.target)"
      >Excluir</b-button>
    </b-modal>

    <!-- Main table element -->
    <b-table
      show-empty
      stacked="md"
      :items="agendamentos"
      :fields="fields"
      :current-page="currentPage"
      :per-page="perPage"
      :filter="filter"
      @filtered="onFiltered"
      striped
      hover
      dark
    >
      <template v-slot:cell(actions)="row">

        <b-button size="sm" variant="outline-danger" class="btn-excluir-agendamento mr-1"  @click="excluir(agendamento, row.item, row.index, $event.target)">Excluir</b-button>

        <b-button size="sm" variant="outline-primary" class="btn-detalhes-agendamento mr-2" @click="info(row.item, row.index, $event.target)">Detalhes </b-button> 

        <b-button size="sm" variant="outline-success" class="btn-alterar-agendamento mr-2" @click="alterar(agendamento, row.item, row.index, $event.target)">Alterar</b-button>
      
      </template>
      
    </b-table>

    <b-row>
      <b-col md="6" class="my-1">
        <b-pagination
          v-model="currentPage"
          :total-rows="totalRows"
          :per-page="perPage"
          class="my-0"
        ></b-pagination>
      </b-col>
    </b-row>

  </div>
</template>

<script>
import Titulo from "../components/titulo.vue";
import AgendamentoService from "../Service/agendamentoService";

export default {
  computed: {
    sortOptions() {
      //Criação das opções de lista
      return this.fields
        .filter(f => f.sortable)
        .map(f => {
          return { text: f.label, value: f.key };
        });
    }
  },
  mounted() {
    this.totalRows = this.agendamentos.length;
    //debugger;
    this.listar();
  },

  data() {
    return {
      agendamentos: [],
      fields: [
        {
          key: "IdAgendamento",
          label: "Id"
        },
        {
          key: "NomeProcedimento",
          label: "Nome do procedimento"
        },
        {
          key: "Pacientes.Nome",
          label: "Nome do paciente"
        },
        {
          key: "DataConsulta",
          label: "Data da Consulta"
        },
        {
          key: "Horario",
          label: "Horario da Consulta"
        },
        { key: "actions", label: "Ações" }
      ],
      totalRows: 1,
      currentPage: 1,
      perPage: 10,
      filter: null,
      infoModal: {
        id: "info-modal",
        title: "",
        content: ""
      },
      agendamento: null
    };
  },

  methods: {
    info(item, index, button) {
      this.agendamento = item;
      
       //console.log(this.agendamento.IdAgendamento);
      this.infoModal.title = this.agendamento.NomeProcedimento;
      this.infoModal.content = JSON.stringify(item, null, 2);
      this.$root.$emit("bv::show::modal", this.infoModal.id, button);

       //this.$router.push({path:'/agendamentos', query:{id: this.agendamento.id}});
    },

    resetInfoModal() {
      this.infoModal.title = "";
      this.infoModal.content = "";
    },

    onFiltered(filteredItems) {
      this.totalRows = filteredItems.length;
      this.currentPage = 1;
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

    listar(){
    AgendamentoService.listarAgendamentos()
      .then(resposta => {
        resposta.data.forEach(element => {
          //configurar o formato de data

          //debugger;
          var data = element.DataConsulta;
          element.DataConsulta = this.organizarData(data, true);
          element.Horario = this.organizarData(data, false);
        });

        this.agendamentos = resposta.data;
      })
      .catch(resposta => {
        console.log(resposta);
      });
  },

  excluir(agendamento, item) {
    
      this.IdAgendamento = item.IdAgendamento;
      console.log(this.IdAgendamento);
      AgendamentoService.excluirAgendamento(this.IdAgendamento).then(() => {
        alert("Agendamento '" + item.NomeProcedimento + "' excluido com sucesso!");
        //feito dessa forma para forçar a listagem a atualizar
        this.agendamento = null;
        this.listar();
      });
    },

  alterar(agendamento, item){
      this.agendamento = item;
       this.IdAgendamento = item.IdAgendamento;
      //console.log(this.agendamento);
      this.$router.replace({
          path: "/agendamentos/alterar?id=" + this.IdAgendamento
      });

    },

  },

  components: {
    Titulo
  },
  
};
</script>

<style>
.pesquisa {
  margin-bottom: 15px;
}
.btn-alterar-agendamento {
  float: right;
  margin-top: 5px;
}
.btn-excluir-agendamento {
  margin-top: 5px;
  float: right;
}
.btn-detalhes-agendamento {
  margin-top: 5px;
  float: right;
}
</style>