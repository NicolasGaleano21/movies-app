import Box from "@mui/material/Box";
import { Route, Routes } from "react-router-dom";
import { ThemeProvider } from "@mui/material";
import { Provider } from "react-redux";
import store from "./data/store";
import Spinner from "./modules/global/Spinner";
import { AlertMessage } from "./modules/global/components/AlertMessage";
import MoviesPage from "./modules/movies";
import { theme } from "./theme";

export default function App() {
  return (
    <ThemeProvider theme={theme}>
      <Provider store={store}>
        <Spinner />
        <AlertMessage />
          <Box component="main">
            <Routes>
              <Route path="/" element={<MoviesPage />} />
            </Routes>
          </Box>
      </Provider>
    </ThemeProvider>
  );
}