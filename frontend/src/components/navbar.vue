<template>
  <div id="navbar">
    <b-navbar type="dark" variant="dark">
      <b-navbar-nav>
        <b-navbar-brand>
          <router-link class="link" to="/agendamentos">Agendamentos</router-link>
        </b-navbar-brand>
        <b-nav-item>
          <router-link class="link" to="/paciente">Paciente</router-link>
        </b-nav-item>
      </b-navbar-nav>
    </b-navbar>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  props: {
    msg: String
  }
};
</script>

<style scoped>
.link {
  color: white;
  text-decoration: none;
  font-size: 18px;
  font-family: Arial, Helvetica, sans-serif;
}

.link:hover {
  color: gray;
}
</style>