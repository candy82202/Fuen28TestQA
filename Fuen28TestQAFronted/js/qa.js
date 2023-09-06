const qa = {
  template: `
  <div>
  
    <form>
    <div class="d-flex">
      <h1>題目 {{ question.id }}</h1> 
    </div> 
      <label>{{ question.text }}</label><br/>
      <textarea name="mytext"
      rows="6"
      cols="100"
      required>
      </textarea>
  </form>  
</div>
    `,
  data() {
    return {
      id: 0,
      question: [],
      titleId: 1,
      quesImg: "./images/que.jpg",
      userInput: "", // Store user input
    };
  },
  methods: {
    async refreshData() {
      const questionId = this.$route.params.id; // Access the question ID from the route params
      try {
        const response = await axios.get(
          `${variables.API_URL}Question/${questionId}`
        );
        this.question = response.data; // Assign the fetched question data
        console.log(this.question);
      } catch (error) {
        console.error("Error fetching question:", error);
      }
    },
  },
  created() {
    this.refreshData();
  },
};
