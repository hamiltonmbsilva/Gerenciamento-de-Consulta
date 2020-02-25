<template>
  <div class="container">
    <div>
      <Titulo texto="Listagem dos Agendamentos" />
    </div>
    <b-row>
      <b-col>
        <b-nav-form class="pesquisa">
          <b-form-input v-model="filter" placeholder="Pesquisar"></b-form-input>
          <b-button variant="outline-success" :disabled="!filter" @click="filter = ''">Limpar</b-button>
        </b-nav-form>
      </b-col>
      <b-col>
        <router-link to="agendamentos/cadastrar">
          <b-button variant="outline-success" class="btn-cadastrar">Cadastrar Agendamentos</b-button>
        </router-link>
      </b-col>
    </b-row>

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
      <template slot="actions" slot-scope="row">
        <b-button size="sm" @click="info(row.item, row.index, $event.target)" class="mr-1">Detalhes</b-button>
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

    <!-- Info modal -->
    <b-modal
      v-if="this.agendamento != null"
      :id="infoModal.id"
      :title="infoModal.title"
      ok-only
      @hide="resetInfoModal"
    >
      <p class="h6">{{fields[1].label +": "+ agendamento.dataConsulta}}</p>
      <p class="h6">{{fields[2].label +": "+ agendamento.nomeProcedimento}}</p>
      <p class="h6">{{fields[3].label +": "+ agendamento.horario}}</p>
    </b-modal>
  </div>
</template>

<script>
import Titulo from "../components/titulo.vue";
import AgendamentoService from "../Service/agendamentoService";

export default {
  computed: {
    sortOptions(){
      //Criação das opções de lista
      return this.fields 
        .filter(f => f.sortable)
        .map(f => {
            return {text: f.label, value: f.key };
        });
    }    
  },
  mounted() {
    this.totalRows = this.agendamentos.length;
    AgendamentoService.listarAgendamentos().then(resposta =>{
      resposta.data.forEach(element => {
        //configurar o formato de data
        element.dataConsulta = this.organizarData(element.dataConsulta);

      });
    });
  },
 data(){
   return{
     agendamentos:[],
     fields: [
       {
         key:"IdAgendamento",
         label: "Id",
         sortable: true,
         sortDirection: "desc"
       },
       {
         key:"dataConsulta",
         label: "Data da Consulta",
         sortable: true,
         class: "text-center"
       },
       {
         key:"horario",
         label: "Horario da Consulta",
         sortable: true,
         class: "text-center"
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
    info(item, index, button){
      this.agendamento = item;

      this.infoModal.title = this.agendamento.idAgendamento;
      this.infoModal.content = JSON.stringify(item, null, 2);
      this.$root.$emit("bv::show::modal", this.infoModal.id, button);
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
    organizarData(d) {
      var dataSplit = String(d).split("T");
      var data = dataSplit[0];
      var time = dataSplit[1];

      var ano = String(data).split("-")[0];
      var mes = String(data).split("-")[1];
      var dia = String(data).split("-")[2];

      var hora = String(time).split(":")[0];
      var minuto = String(time).split(":")[1];

      return `${dia}/${mes}/${ano} ${hora}:${minuto}`;
    }
  }, 
  components: {
    Titulo
  }
};
</script>
<style>
    .pesquisa{
       margin-bottom: 15px;       
    }
    .btn-cadastrar {
      float: right;
    }
</style>