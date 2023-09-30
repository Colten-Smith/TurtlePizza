<template>
  <div class="home">
    <h2>Welcome to Turtle Pizza</h2>
    <div class="link">
    <router-link to="/login">Login</router-link>
    </div>
    
    <div class="link">
    <router-link to="/register">New Employee? Register here.</router-link>
    </div>
  </div>
</template>

<style>
.home {
  text-align: center;
  padding: 20px;
  font-size: 35px;
}
.link {
  margin-bottom: 10px;
}
h2 {
  margin-bottom: 40px;
}
</style>
