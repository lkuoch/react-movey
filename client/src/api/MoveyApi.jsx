//# Movey service endpoint
import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:44349/api/movey"
});
