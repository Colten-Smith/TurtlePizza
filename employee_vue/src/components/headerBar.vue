<template>
  <div class="header">
    <h1>Turtle Pizza - PZA</h1>
    <nav>
      <router-link v-if="isAuthenticated" to="/orders" class="nav-link"
        >Orders</router-link>
      <router-link v-if="isAuthenticated" to="/editmenu" class="nav-link"
        >Edit Menu</router-link>
      <router-link v-if="isAuthenticated" to="/logout" class="nav-link"
        >Logout</router-link>
    </nav>
  </div>
</template>

<script>
export default {
  computed: {
    isAuthenticated() {
      return this.$store.state.token !== "";
    },
  },
  methods: {
    logout() {
      this.$store.commit("LOGOUT"); // Commit the LOGOUT mutation to clear authentication state
      this.$router.push("/login"); // Redirect to the login page
    },
  },
};
</script>

<style scoped>
.header {
  background-color: green;
  color: white;
  text-align: left;
  padding: 10px 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

h1 {
  margin-left: 10px;
}

nav {
  display: flex;
  gap: 30px;
  margin-right: 15px;
}
.nav-link {
  color: black;
}
.nav-link:hover {
  color: grey;
}
</style>






