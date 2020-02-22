<template>
  <div class="container">
    <div>
      <Titulo texto="Listagem dos Agendamentos" />
    </div>
    <b-row>
      <b-col>
        <b-nav-form style="margin-top: 15px;">
          <b-form-input v-model="filter" placeholder="Pesquisar"></b-form-input>
          <b-button variant="outline-success" :disabled="!filter" @click="filter = ''">Limpar</b-button>
        </b-nav-form>
      </b-col>
      <b-col>
        <router-link to="pedidos/cadastrar">
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
      <p class="h6">{{fields[1].label +": "+ agendamento.dataPedido}}</p>
      <p class="h6">{{fields[2].label +": "+ agendamento.valorTotal}}</p>
    </b-modal>
  </div>
</template>