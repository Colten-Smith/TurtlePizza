<template>
  <div id="submissionFormBody" v-on:blur="updateOrder()">
      <div id="submissionTextBoxes" v-on:blur="updateOrder()">
          <p>Name:</p>
          <input type="text" id="nameInput" class="submissionText" v-model="value.name" v-on:blur="updateOrder()"/>
          <p>Notes:</p>
          <textarea id="notes" class="submissionText" v-model="value.notes" v-on:blur="updateOrder()"/>
      </div>
      <button id="finalSubmit" v-on:blur="updateOrder()" v-on:click="submitOrder()">SUBMIT</button>
  </div>
</template>

<script>
import OrderService from '../services/OrderService.js'
export default {
name: "checkout-submission-form",
data(){
    return{
        value: {
            name: "",
            notes: ""
        }
    }
},
methods: {
    updateOrder(){
        this.$store.commit("UPDATEORDERINFO", this.value)
    },
    async submitOrder(){
        this.$store.commit("UPDATEORDERADDRESS", (await OrderService.submitAddressGetID(this.$store)).data.addressID)
        this.$store.commit("UPDATEORDERPAYMENT", (await OrderService.submitPaymentGetID(this.$store)).data.paymentID)
        await OrderService.submitOrder(this.$store)
        this.$router.push("/order")
    }
}
}
</script>

<style>
#submissionFormBody{
    width: 75vw;
    margin-top: 5vh;
    background-color: white;
    border: 2px solid whitesmoke;
    width: 75vw;
    min-height: 25vh;
}
#submissionTextBoxes{
    width: max-content
}
#notes{
    min-height: 20vh;
    width: 60vw;
    resize: none;
}
.submissionText{
    width: 100%
}
#finalSubmit{
    width: 15vw;
    font-size: 3vw;
    margin-top: 10px;
}
</style>