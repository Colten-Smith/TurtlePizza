<template>
<div class="mainContainer">
  <div class="checkoutBody">
    <h1 class="pageTitle">Cart</h1>
      <div id="itemsSection" class="checkoutSection">
          <checkout-item-list/>
      </div>
      <h2>Ready to eat? Checkout Below</h2>
      <div id="addressSection" class="checkoutSection">
        <address-form v-model="test"/>
      </div>
      <div id="paymentSection" class="checkoutSection">
        <payment-form/>
      </div>
      <div id="extraInfo" class="checkoutSection">
        <checkout-submission-form/>
      </div>
  </div>
</div>
</template>

<script>
import CheckoutItemList from '../components/CheckoutItemList.vue'
import AddressForm from '../components/AddressForm.vue'
import PaymentForm from '../components/PaymentForm.vue'
import CheckoutSubmissionForm from '../components/CheckoutSubmissionForm.vue'
export default {
  components: { 
    CheckoutItemList,
    AddressForm,
    PaymentForm,
    CheckoutSubmissionForm
   },
   data(){
     return{
       test: {}
     }
   }

}
</script>

<style>
h2 {
 text-align: center;
 margin-top: 30px;
 font-size: 4vh;
}
.mainContainer {
 display: flex;
  
  align-items: center;
  min-height: 100vh;
}
.checkoutBody{
  
  flex-direction: column;
  align-items: center;
  width: 75vw;
  max-width: 900px;
  margin-top: 50px;
  margin-bottom: 50px;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4);
  background-color: lightgray;
  background-image: url('/public/img/headTransparent.png');
  background-repeat: repeat;
}
.pageTitle {
   margin-bottom: 20px;
  font-size: 50px;
  color: rgb(7, 128, 13);
   font-family: "TurtlesFont", sans-serif;
  text-shadow: 2.5px 1px #af0808;
  text-align: center;
}
.checkoutSection{
  display: flex;
  justify-content: center;
  flex-basis: 100%; 
  margin-top: 20px;
  
}
</style>