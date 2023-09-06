const app = Vue.createApp({});

app.component("OOP", OOP);
app.component("database", database);
app.component("cSharp", cSharp);
app.component("git", git);
app.component("randomquiz", randomquiz);
app.component("qa", qa);
const router = VueRouter.createRouter({
  history: VueRouter.createWebHashHistory(),
  routes: [
    { path: "/", component: OOP },
    { path: "/oop", component: OOP },
    { path: "/database", component: database },
    { path: "/cSharp", component: cSharp },
    { path: "/git", component: git },
    { path: "/randomquiz", component: randomquiz },
    { path: "/qa/:id", component: qa },
  ],
});
app.use(router);
app.mount("#app");
