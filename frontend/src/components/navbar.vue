<template>
  <div id="navbar">
    <b-navbar type="dark" variant="dark">
      <b-navbar-nav>
        <b-navbar-brand>
          <router-link class="link" to="/">Home</router-link>
        </b-navbar-brand>
        <b-navbar-brand>
          <router-link class="link" to="/agendamentos">Todos Agendamentos</router-link>
        </b-navbar-brand>
        <b-nav-item>
          <router-link class="link" to="">Paciente</router-link>
        </b-nav-item>
        <b-nav-item>
          <router-link class="link" to="">Anaminese</router-link>
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
}

.link:hover {
  color: gray;
}
</style>