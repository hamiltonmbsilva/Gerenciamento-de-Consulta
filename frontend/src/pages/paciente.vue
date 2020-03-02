<template>
  <div class="container">
    <div>
      <Titulo texto="Listagem dos Pacientes" />
    </div>
    <b-row>
      <b-col>
        <b-nav-form class="pesquisa">
          <b-form-input v-model="filter" placeholder="Pesquisar"></b-form-input>
          <b-button variant="outline-success" :disabled="!filter" @click="filter = ''">Limpar</b-button>
        </b-nav-form>
      </b-col>
      <b-col>
        <router-link to="paciente/cadastrar">
          <b-button variant="outline-success" class="btn-cadastrar">Cadastrar Pacientes</b-button>
        </router-link>
      </b-col>
    </b-row>

      <!-- Info modal -->
    <b-modal
      v-if="this.paciente != null"
      :id="infoModal.id"
      :title="infoModal.title"
      ok-only
      @hide="resetInfoModal"
    >
      <p class="h6">{{fields[1].label +": "+ paciente.Codigo}}</p>
      <p class="h6">{{fields[2].label +": "+ paciente.Nome}}</p>
      <p class="h6">{{fields[3].label +": "+ paciente.CPF}}</p>
      <p class="h6">{{fields[4].label +": "+ paciente.DataDeNascimento}}</p>
      <p class="h6">{{fields[5].label +": "+ paciente.Planos}}</p>  

      <b-button
        variant="outline-success"
        class="btn-alterar-paciente"
        @click="alterar(paciente, row.item, row.index, $event.target)"
      >Alterar </b-button>
      <b-button
        variant="outline-danger"
        class="btn-excluir-paciente"
        @click="excluir(paciente, row.item, row.index, $event.target)"
      >Excluir </b-button>
    
    </b-modal>

    <!-- Main table element -->
    <b-table     
      show-empty
      stacked="md"
      :items="pacientes"
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

        <b-button size="sm" variant="outline-danger" class="btn-excluir-paciente mr-2"  @click="excluir(paciente, row.item, row.index, $event.target)">Excluir</b-button>

        <b-button size="sm" variant="outline-primary" class="btn-detalhes-paciente mr-2" @click="info(row.item, row.index, $event.target)">Detalhes </b-button> 

        <b-button size="sm" variant="outline-success" class="btn-alterar-paciente mr-2" @click="alterar(paciente,  row.item, row.index, $event.target)">Alterar</b-button>
      
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
import PacienteService from "../Service/pacienteService";

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
    this.totalRows = this.pacientes.length;

    this.listar();
  },

  data() {
    return {
      pacientes: [],
      fields: [
        {
          key: "IdPaciente",
          label: "Id",
          sortable: true,
        },
        {
          key: "Codigo",
          label: "Código do paciente"
        },
        {
          key: "Nome",
          label: "Nome do paciente"
        },
        {
          key: "CPF",
          label: "Cpf"
        },
        {
          key: "DataDeNascimento",
          label: "Data de nascimento"
        },
        {
          key: "Planos",
          label: "Planos"
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
      paciente: null
    };
  },
  methods: {
    info(item, index, button) {
      this.paciente = item;

      this.infoModal.title = this.paciente.Nome;
      this.infoModal.content = JSON.stringify(item, null, 2);
      this.$root.$emit("bv::show::modal", this.infoModal.id, button);

      this.$router.push({path:'/paciente', query:{id: this.paciente.id}});
    },
    resetInfoModal() {
      this.infoModal.title = "";
      this.infoModal.content = "";
    },
    onFiltered(filteredItems) {
      this.totalRows = filteredItems.length;
      this.currentPage = 1;
    },

    listar(){
      PacienteService.listar()
      .then(resposta => {
        resposta.data.forEach(element => {
          //configurar o formato de data
          element.DataDeNascimento = this.organizarData(
            element.DataDeNascimento,
            true
          );

          //  element.Planos = this.tranformarPlanos(
          //    element.Planos
          //  );
                if(element.Planos == 0){
                    element.Planos = 'UNIMED';
                }
                else if(element.Planos == 1){
                     element.Planos = 'AMIL';
                }
                else if(element.Planos == 2){
                     element.Planos = 'SAUDE_SERVIDOR';
                }
                else if(element.Planos == 3){
                    element.Planos = 'BRADESCO';
                }
                else if(element.Planos == 4){
                     element.Planos = 'OUTROS';
                }

        });

        this.pacientes = resposta.data;
      })
      .catch(resposta => {
        console.log(resposta);
      });
  
    },

    tranformarPlanos(planos){

      //console.log(planos);
      
            //'UNIMED = 0', 'AMIL = 1', 'SAUDE_SERVIDOR = 2', 'BRADESCO = 3', 'OUTROS = 4'
                if(planos == 0){
                    planos.Planos = 'UNIMED';
                }
                else if(planos == 1){
                     planos.Planos = 'AMIL';
                }
                else if(planos == 2){
                     planos.Planos = 'SAUDE_SERVIDOR';
                }
                else if(planos == 3){
                    planos.Planos = 'BRADESCO';
                }
                else if(planos == 4){
                     planos.Planos = 'OUTROS';
                }
    },

    excluir(paciente,item) {
      this.IdPaciente = item.IdPaciente;
     
      PacienteService.excluirPaciente(this.IdPaciente).then(() => {
        alert("Paciente '" + item.Nome + "' excluido com sucesso!");
        //feito dessa forma para forçar a listagem a atualizar
        this.pacientes = null;
        this.listar();
      });
    },

    alterar(paciente, item){
      this.paciente = item;
       this.IdPaciente = item.IdPaciente;
      console.log(this.paciente);
      this.$router.replace({
          path: "/paciente/alterar?id=" + this.IdPaciente
      });

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
    }
  },
  components: {
    Titulo
  }
};
</script>
<style>
.pesquisa {
  margin-bottom: 15px;
}
.btn-cadastrar {
  float: right;
}
.btn-alterar-paciente{
   margin-top: 5px;
  float: right;
}
.btn-excluir-paciente {
  margin-top: 5px;
  float: right;
}
.btn-detalhes-paciente{
  margin-top: 5px;
  float: right;
}
</style>