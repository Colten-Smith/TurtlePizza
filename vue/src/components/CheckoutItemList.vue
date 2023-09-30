<template>
  <div id="checkoutListBody">
      <div class="itemText" v-for="item in pizzas" :key="item.itemKey"><p>{{item.name}}</p><p class="money">{{twoDecimal(item.price)}}</p></div>
      <div class="itemText" v-for="item in sides" :key="item.itemKey"><p>{{item.name}}</p><p class="money">{{twoDecimal(item.price)}}</p></div>
      <div class="itemText" v-for="item in drinks" :key="item.itemKey"><p>{{item.name}}</p><p class="money">{{twoDecimal(item.price)}}</p></div>
      <p id="total" class="money">{{twoDecimal(total)}}</p>
  </div>
</template>

<script>
export default {
    name: "checkout-item-list",
    data(){
        return{
            number: 1
        }
    },
    computed: {
        pizzas(){
            return this.$store.state.selectedPizzas
        },
        sides(){
            return this.$store.state.selectedSides
        },
        drinks(){
            return this.$store.state.selectedDrinks
        },
        total(){
            let output = 0;
            this.pizzas.forEach(element => {
                output += element.price
            });
            this.sides.forEach(element => {
                output += element.price
            });
            this.drinks.forEach(element => {
                output += element.price
            });
            return output;
        }
    },
    methods: {
        twoDecimal(num){
            return num.toFixed(2)
        }
    }
}
</script>

<style>
.money:before{
    content: '$'
}
#checkoutListBody{
    background-color: white;
    border: 2px solid whitesmoke;
    width: 75vw;
}
.itemText{
    display: flex;
    justify-content: space-between;
    width: 100%;
    border-bottom: 1px solid lightgrey;
}
#total{
    text-align: right;
    border-top: 1px solid black;
}
</style>