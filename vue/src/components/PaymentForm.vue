<template>
  <div id="paymentFormBody" v-on:blur="updatePayment()">
      <label for="cardNum">Card Number:</label>
      <input type="text" id="cardNum" minlength="16" maxlength="16" v-model="value.cardNum" v-on:blur="updatePayment()"/>
      <label for="expDate">Expiration Date:</label>
      <input id="expDate" type="month" v-model="value.expDate" v-on:blur="updatePayment()"/>
      <label for="cvc">CVC:</label>
      <input type="number" id="cvc" minlength="3" maxlength="3" v-model.number="value.cvc" v-on:blur="updatePayment()"/>
  </div>
</template>

<script>
export default {
    name: "payment-form",
    data(){
      return{
        value: {
          cardNum: "",
          expDate: "2023-08",
          cvc: 0,
          userID: 0
        }
      }
    },
    methods:{
      updatePayment(){
        this.$store.commit("UPDATEPAYMENT", this.value)
      }
    }
}
</script>

<style>
    #paymentFormBody{
  display: flex;
  flex-direction: column;
    margin-top: 5vh;
    background-color: white;
    border: 2px solid whitesmoke;
    width: 75vw;
    min-height: 25vh;}
</style>