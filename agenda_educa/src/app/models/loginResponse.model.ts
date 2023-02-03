export interface LoginResponse {
  email: string;
  token: {
    access_token: string;
  };
}
