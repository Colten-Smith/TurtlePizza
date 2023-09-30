<template>
  <div id="login">
    <form id="login-form" @submit.prevent="login">
      <h1 >Please Sign In</h1>
      <div role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div role="alert" v-if="this.$route.query.registration">
        Welcome to Turtle Pizza!, please sign in.
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input type="text" id="username" v-model="user.username" required autofocus />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required />
      </div>
      <button type="submit">Sign in</button>
      <p>
        <router-link v-if="showLoginForm" :to="{ name: 'register' }">First day? Register here.</router-link>
      </p>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false,
      showLoginForm: true
    };
  },
 methods: {
  login() {
    authService
      .login(this.user)
      .then(response => {
        if (response.status == 200) {
          this.$store.commit("SET_AUTH_TOKEN", response.data.token);
          this.$store.commit("SET_USER", response.data.user);
          // Check if the user was trying to access a protected route before login
          const intendedRoute = this.$route.query.redirect || '/orders';
          this.$router.push(intendedRoute); // Redirect to intended route or orders page
        }
      })
      
  }
}
};
</script>

<style scoped>
#login {
  display: flex;
  justify-content: center;
  align-items: flex-start;
  min-height: 100vh;
}

#login-form {
  background-color: white;
  padding: 40px;
  border-radius: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4);
  margin-top: 30px;
}

.form-input-group {
  margin-bottom: 1rem;
}

label {
  margin-right: 0.5rem;
}

button[type="submit"] {
  margin-top: 20px;
  padding: 10px 20px;
  background-color: #f0f0f0;
  border-radius: 5px;
  color: #333;
  font-weight: bold;
  border: none;
  cursor: pointer;
  transition: background-color 0.3s, color 0.3s;
}

button[type="submit"]:hover {
  background-color: #333;
  color: white;
}
</style>