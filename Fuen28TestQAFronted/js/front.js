const OOP = {
  template: ` 
  <div class="row gy-5"> 
    <div
      class="col-lg-4 menu-item"
      v-for="(que, index) in questions" :key="index"
    >
      
  <div class="centerflipcards">
  <div class="square-flip">
  <div
    class="square"
    data-image="quesImg"
  >
    <div class="square-container">
      <div class="align-center">
      <img
      src="images/que.jpg"
        class="boxshadow"
        alt=""
      />
      </div>
      <h2 class="textshadow">{{ index + 1 }}</h2>
      
    </div>
    <div class="flip-overlay"></div>
  </div>
  <div
    class="square2"
   
  >
    <div class="square-container2">
      <div class="align-center">
      <a  :href="queLinkURL + que.id"
        target="_blank"
        class="boxshadow kallyas-button"
        >題目內容</a
      ></div>
    </div>
    <div class="flip-overlay"></div>
  </div>
  </div>
  <br />
  </div></div></div>
  `,
  data() {
    return {
      questions: [],
      titleId: 1,
      quesImg: "./images/que.jpg",
      queLinkURL: "test.html#/qa/",
    };
  },
  methods: {
    async refreshData() {
      try {
        const response = await axios.get(
          `${variables.API_URL}Question?titleId=4`
        );
        this.questions = response.data; // Assign the fetched question data
        console.log(this.questions);
      } catch (error) {
        console.error("Error fetching question:", error);
      }
    },
  },

  mounted: function () {
    console.log("發送");
    this.refreshData();
  },
};
