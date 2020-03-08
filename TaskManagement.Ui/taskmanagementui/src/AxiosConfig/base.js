import axios from "axios";
import { history } from "../index";

const axiosConfig = axios.create({
  baseURL: "https://localhost:5001/api/",
  headers: {
    "Content-Type": "application/json"
  }
});

axiosConfig.interceptors.response.use(
  response => {
    return response;
  },
  error => {
    if ((error.status = 401)) {
      localStorage.clear();
      history.push("/login");
    }
  }
);

export default axiosConfig;
