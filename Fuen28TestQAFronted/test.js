var daily = {
  coding: "3",
  habit: "2",
  greet: function () {
    this.coding += "1";
    return this.coding.length + this.habit.length;
  },
};
console.log(daily.greet() % 5);

let daily = "1" + " " + "2";
daily += "3";
console.log(daily);
daily = ["4", " ", "5"].join(daily);
console.log(daily);
daily = daily.concat(" ", "6");
console.log(daily);
console.log(daily[3]);
