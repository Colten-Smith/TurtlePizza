<template>
  <div id="addressFormBody" v-on:blur="updateAddress()">
    <label for="streetAddress">Street Address:</label>
      <input type="text" id="streetAddress" v-model="value.streetAddress" v-on:blur="updateAddress()"/>
    <label for="aptNumber">Apt Number:</label>
      <input type="number" id="aptNumber" min="0" v-model.number="value.aptNum" v-on:blur="updateAddress()"/>
    <label for="zip">Zip Code:</label>
      <input type="number" id="zip" min="11111" max="99999" v-model.number="value.zip" v-on:blur="updateAddress()"/>
    <label for="city">City:</label>
      <input type="text" id="city" v-model="value.city" v-on:blur="updateAddress()"/>
    <label for="state">State:</label>
      <input type="text" id="state" minlength="2" maxlength="2" v-on:blur="updateAddress()" v-model="value.state" onkeyup="this.value = this.value.toUpperCase();"/>

  </div>
</template>

<script>
export default {
    name: "address-form",
    data(){
      return{
    value: {
  streetAddress: "",
  aptNum: 0,
  zip: 0,
  city: "",
  state: "",
  userID: 0
      }
    }
},
methods: {
  updateAddress(){
    this.$store.commit("UPDATEADDRESS", this.value)
  }
}

}
</script>

<style>
#addressFormBody{
  display: flex;
  flex-direction: column;
    margin-top: 5vh;
    background-color: white;
    border: 2px solid whitesmoke;
    width: 75vw;
    min-height: 25vh;
}
</style>