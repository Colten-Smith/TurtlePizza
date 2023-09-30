<template>
  <div>
    <div class="home-image animate__animated animate__zoomInDown">
      <router-link to="/">
        <img src="/img/pizzabox.jpg" alt="Home" />
      </router-link>
    </div>
    <nav class="navbar is-dark" role="navigation" aria-label="main navigation">
      <div class="navbar-start">
        <router-link to="/account" class="navbar-item account-link">
          <div class="account-overlay">
            <img src="/img/account.png" alt="Account" class="account-image" />
          </div>
          <div class="account-tag">Account</div>
        </router-link>
      </div>
      <div class="navbar-center">
        <router-link to="/order" class="navbar-item custom-font"
          >Order Online</router-link
        >
        <router-link to="/menu" class="navbar-item custom-font"
          >Menu</router-link
        >
        <router-link to="/contact" class="navbar-item custom-font"
          >Contact</router-link
        >
      </div>
      <div class="navbar-end">
        <router-link to="/checkout" class="navbar-item cart-link">
          
          <div class="cart-overlay">
            <img src="/img/cart.png" alt="Cart" class="cart-image" />
          </div><div class="cart-tag">Cart</div>
        </router-link>
      </div>
    </nav>
  </div>
</template>

<style scoped>
@import "~animate.css/animate.min.css";
@font-face {
  font-family: "TurtlesFont";
  src: url("@/Fonts/Turtles.otf") format("opentype");
}

.custom-font {
  font-family: "TurtlesFont", sans-serif;
  color: black;
  font-size: 30px;
  width: max-content;
  text-align: center;
  height: min-content;
  vertical-align: middle;
  max-width: 25vw;
  transition: color 0.65s;
}

.custom-font:visited {
  background-color: whitesmoke;
  color: black;
}

.custom-font:hover {
  background-color: darkgreen;
  color: #ec0707;
}

.home-image {
  text-align: center;
  padding: 20px;
}

.home-image img {
  max-width: 400px;
  height: auto;
}

.navbar {
  background-color: rgb(5, 139, 27);
  display: flex;
  flex-wrap: nowrap;
}

.navbar-logo {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-grow: 1;
}

.navbar-center {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-grow: 1;
}

.navbar-item:focus {
  background-color: darkgreen;
  outline: none;
}

.navbar-end {
  display: flex;
  align-items: center;
  margin-right: 5px;
}

.navbar-start {
  display: flex;
  align-items: center;
  margin-left: 5px;
}

.account-link {
  display: inline-block;
  
}
.account-overlay {
  margin-left: 6px;

}

.account-image {
  max-width: 32px;
  transition: opacity 0.5s, transform 0.5s;
  
}
.cart-overlay {
  margin-left: 2px;
}

.cart-link {
  display: inline-block;
  font-weight: bold;
  color: #333;
}

.cart-image {
  max-width: 32px;
  transition: opacity 0.5s, transform 0.5s;
}

.navbar-tag {
  
  color: white;
  text-align: center;
  margin-top: 5px;
  width: 100%;
}

.account-tag,
.cart-tag {
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 12px;
}
</style>
