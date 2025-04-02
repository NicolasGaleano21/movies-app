import { createTheme } from "@mui/material/styles";

export const theme = createTheme({
  palette: {
    primary: { main: "#2e6e99" },
    secondary: { main: "#6e6e6e" },
    error: { main: "#b02a37" },
  },
  typography: {
    fontFamily: "Source Sans Pro, sans-serif",
    fontSize: 18,
  },
});
