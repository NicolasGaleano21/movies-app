import { createSlice } from "@reduxjs/toolkit";

interface GlobalContextState {
  showSpinner: boolean;
  alert: { show: boolean; message: string; type: "success" | "error" };
}

const initialState: GlobalContextState = {
  showSpinner: false,
  alert: { show: false, message: "", type: "success" },
};

const globalSlice = createSlice({
  name: "spinner",
  initialState,
  reducers: {
    showSpinner: (state) => {
      state.showSpinner = true;
    },
    hideSpinner: (state) => {
      state.showSpinner = false;
    },
    showAlert: (state, action) => {
      state.alert = {
        show: true,
        message: action.payload.message,
        type: action.payload.type,
      };
    },
    hideAlert: (state) => {
      state.alert = { ...state.alert, show: false };
    },
  },
});

export const { showSpinner, hideSpinner, showAlert, hideAlert } =
  globalSlice.actions;
export default globalSlice.reducer;
