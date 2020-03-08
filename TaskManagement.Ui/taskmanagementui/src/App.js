import React from "react";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import MainStore from "./Redux/MainStore";
import BaseComponent from "./Components/BaseComponent";

function App() {
  return (
    <Provider store={MainStore}>
      <BrowserRouter>
        <BaseComponent />
      </BrowserRouter>
    </Provider>
  );
}

export default App;
