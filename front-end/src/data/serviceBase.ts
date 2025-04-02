import axios, {
  AxiosInstance,
  AxiosError
} from "axios";

export default abstract class ServiceBase {
  protected readonly client: AxiosInstance;

  /**
   * Constructor initializes the Axios client with a base URL and sets up interceptors.
   * @param service - The specific service endpoint to append to the base URL.
  */
  constructor() {
    this.client = axios.create({
      baseURL: import.meta.env.VITE_API_URL,
      headers: { "Content-Type": "application/json" },
    });
    this.setupRequestInterceptor();
    this.setupResponseInterceptor();
  }

  /**
   * Sets up a request interceptor for modifying requests before they are sent.
   * TODO: Add token authentication to the request headers.
  */
  private setupRequestInterceptor(): void {
    this.client.interceptors.request.use((config) => {
      return config;
    });
  }

  /**
   * Sets up a response interceptor to handle errors globally.
   * If an error occurs, extracts the error message.
  */
  private setupResponseInterceptor(): void {
    this.client.interceptors.response.use(
      (response) => response,
      (error: AxiosError) => Promise.reject(error.message)
    );
  }
}
