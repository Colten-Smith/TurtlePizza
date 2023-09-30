<template>
  <div id="body">
    <div class="account-container">
      <h1 class="account-title">Are You A Member?</h1>
      <h2 class="account-filler">Joining allows you to save your custom orders, addresses, and payment info so there's less time between you and delicious eats!</h2>
      <div class="links-container">
        <router-link to="/login" class="account-login">Login Here!</router-link>
        <router-link to="/register" class="account-register">Sign up now!</router-link>
      </div>
      <!-- Add more content here if needed -->
    </div>
  </div>
</template>

<script>
export default {
  name: 'Account'
};
</script>

<style>
#body {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
}

.account-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 75vw;
  max-width: 900px;
  margin-top: 50px;
  margin-bottom: 50px;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4);
  background-color: white;
  background-image: url('/public/img/headTransparent.png');
  background-repeat: repeat;
  
 
  max-height: calc(100vh - 100px); /* Adjust as needed */
}

.account-title {
  margin-bottom: 20px;
  font-size: 50px;
  color: rgb(7, 128, 13);
   font-family: "TurtlesFont", sans-serif;
  text-shadow: 2.5px 1px #af0808;
  
}
.account-filler {
font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
text-align: center;
font-size: 150%;

}

.links-container {
  text-align: center;
  display: inline-block;
  margin: 0.5rem;
  padding: 1rem 2rem;
  background-color: #f0f0f0;
  border-radius: 5px;
 
  color: #333;
  font-weight: bold;
  
}

.account-link {
 display: inline-block;
 
  color: #333;
  font-weight: bold;
  
}
.account-login {
  text-align: center;
  display: inline-block;
  margin: 0.5rem;
  padding: 1rem 2rem;
  background-color: #f0f0f0;
  border-radius: 5px;
  text-decoration: none;
  color: #333;
  font-weight: bold;
 
  border: solid black 1px;
}
.account-register {
  text-align: center;
  display: inline-block;
  margin: 0.5rem;
  padding: 1rem 2rem;
  background-color: #f0f0f0;
  border-radius: 5px;
  text-decoration: none;
  color: #333;
  font-weight: bold;
  
  border: solid black 1px;
}



.account-link:hover {
  background-color: #333;
  color: white;
}
</style>
