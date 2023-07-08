import axios from "axios";

export default {
  async Login(email: string) {
    return axios.get(`api/User/Login?email=${email}`);
  },
  async GetPayments(userId: number) {
    return axios.get(`api/User/GetUserPayments?userId=${userId}`);
  },
  async AddPayment(serviceId: number, ammount: number) {
    return axios.get(`api/User/AddPayment?serviceId=${serviceId}&ammount=${ammount}`);
  },
  async RemovePayment(paymentId: number) {
    return axios.get(`api/User/RemovePayment?paymentId=${paymentId}`);
  },
  async RemovePayments(paymentIds: number[]) {
    return axios.post(`api/User/RemovePayments`, paymentIds);
  }
}
