<template>
  <div class="container">
    <div>

    </div>
    <div>
      <b-form @submit="salvar" @reset="onReset" v-if="show">
        <b-form-group id="input-group-1" label="Código Interno:" label-for="input-1">
          <b-form-input
            v-model="form.codInterno"
            type="number"
            required
            @change="validateCodInterno"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-1" label="Código de barras:" label-for="input-1">
          <b-form-input v-model="form.codBarras" type="number" required @change="validateCodBarras"></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Descrição:" label-for="input-2">
          <b-form-input v-model="form.descricao" required></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-1" label="Valor de venda:" label-for="input-1">
          <b-form-input v-model="form.valorVenda" type="number" required></b-form-input>
        </b-form-group>

        <b-button
          @click="salvar()"
          v-if="path === '/agendamentos/cadastrar'"
          variant="success"
          style="margin-right: 10px;"
        >Cadastrar</b-button>

        <b-button
          @click="salvar()"
          v-if="path === '/agendamentos/alterar'"
          variant="success"
          style="margin-right: 10px;"
        >Alterar</b-button>

        <b-button
          v-if="path === '/agendamentos/cadastrar' "
          type="reset"
          variant="secondary"
          style="margin-right: 10px;"
        >Limpar</b-button>

        <router-link to="/agendamentos">
          <b-button type="reset" variant="danger" class="btn-cadastrar">Voltar</b-button>
        </router-link>
      </b-form>
    </div>
  </div>
</template>

<script>
import Titulo from "../components/titulo.vue";
//import AgendamentoService from "../Service/agendamentoService";
export default {   
  // components: {
  //   Titulo
  // },
  data(){
    return{
      form: {
        idProduto: null,
        codInterno: null,
        codBarras: null,
        descricao: "",
        valorVenda: null
      },
      produto: null,
      path: null,
      show: true
    };
  },
  mounted() {
    this.path = window.location.pathname;
    this.getAgendamento();
  },
}
</script>