<template>
  <body class="mainContainer">
    <router-link to="/custom" id="customPizzaButton" class="orderButton redButton orderSection">
      <h1 class="buttonText">BUILD YOUR OWN</h1>
    </router-link>
    <router-link to="/specialties" id="specialtyButton" class="orderButton orderSection">
      <i class="fas fa-pizza-slice"></i>
      <div class="spacer"></div>
      <h1 class="buttonText">Specialties</h1>
    </router-link>
    <div id="sidesBox" class="buttonContainer orderSection">
      <router-link to="/wings" id="wingsButton" class="orderButton smallButton leftButton">
        <i class="fas fa-drumstick-bite"></i>
        <h1 class="buttonText">
          Wings</h1>
      </router-link>
      <router-link to="/sides" id="sidesButton" class="orderButton smallButton">
        <i class="fas fa-bowl-food"></i>
        <h1 class="buttonText">Sides</h1>
      </router-link>
      <router-link to="/drinks" id="drinksButton" class="orderButton smallButton rightButton">
        <i class="fas fa-wine-bottle"></i>
        <h1 class="buttonText">Drinks</h1>
      </router-link>
    </div>
    <router-link to="/checkout" id="completeButton" class="orderButton redButton orderSection">
      <h1 class="buttonText">COMPLETE ORDER</h1>
    </router-link>
  </body>
</template>

<script>
export default {
  
};
</script>

<style>
.mainContainer {
  display: flex;
  flex-flow: column nowrap;
  align-items: center;
}
.orderButton {
  display: flex;
  border: 2px solid lightgray;
  background-color: white;
  width: 100%;
  justify-content: center;
  align-items: center;
  color: black;
}
.orderButton:hover{
  background-color: lightgrey;
}
.orderButton:focus{
  background-color: grey;
}
.smallButton {
  width: 1;
  margin: 0% 1%;
}
.leftButton {
  margin: 0 1% 0 0;
}
.rightButton {
  margin: 0 0 0 1%;
}
.orderSection {
  width: 40vw;
  height: 21vh;
  margin: 1vh 0vh 1vh 0vh;
  min-height: 100px;
  min-width: 300px;
}
.redButton {
  background-color: crimson;
  color: whitesmoke;
}
.redButton:hover{
  background-color: darkred;
  color: whitesmoke;
}
.redButton:focus{
  background-color: maroon;
  color: whitesmoke;
}
.buttonContainer {
  display: flex;
  justify-items: space-between;
}
.buttonText {
  font-family: "TurtlesFont", sans-serif;
  display: block;
  font-size: 2.5vmax;
}
.fas{
  display: block;
  font-size: xx-large;
}
.newLine{
  display: block;
}
.smallButton{
  flex-direction: column;
}
.spacer{
  min-width: 20px;
}
</style>