<script setup lang="ts">
import UserService from '@/services/UserService';
import { computed, ref } from 'vue';
import { DateTime } from "luxon";

const userSs = sessionStorage.getItem('user');
const user = ref();
if (userSs) {
    user.value = JSON.parse(userSs);
}

const services = ref([] as any[]);

const getPayments = () => {
    UserService.GetPayments(user.value.Id)
        .then((data) => {
            services.value = data.data;
        });
};

getPayments();

const payments = computed(() => {
    let payments = [] as any[];

    if (!services.value) {
        payments;
    }

    services.value.forEach(service => {
        if (service.Payments.length > 0) {
            service.Payments.forEach((payment: any) => {
                payments.push(
                    {
                        ...payment,
                        ServiceName: service.Name
                    });
            });
        }
    })
    console.log(payments);
    return payments;
});

const showPayments = computed(() => payments.value && payments.value.length > 0);

const serviceSelected = ref();
const ammount = ref(0);

const addPayment = () => {
    const isValid = validate();
    if (!isValid) {
        return;
    }
    UserService.AddPayment(serviceSelected.value, ammount.value)
        .then(() => {
            getPayments();
            clear();
        });
};

const validate = () => {
    let isValid = true;

    if (!serviceSelected.value) {
        alert('Must select a service');
        isValid = false;
    }

    if (ammount.value <= 0) {
        alert('Must have a valid ammount');
        isValid = false;
    }

    return isValid;
}

const clear = () => {
    serviceSelected.value = '';
    ammount.value = 0;
};

const remove = (paymentId: number) => {
    UserService.RemovePayment(paymentId)
        .then(() => {
            getPayments();
            setTimeout(() => {
                alert('Payment removed');
            }, 100);
        });
};

const bulkRemove = () => {
    if (selectedPayments.value.length == 0) {
        alert("No payments selected");
        return;
    }
    UserService.RemovePayments(selectedPayments.value)
        .then(() => {
            getPayments();
            setTimeout(() => {
                alert('Payments removed');
            }, 100);
        });
};

const selectedPayments = ref([] as number[]);
</script>

<template>
    <div class="flex-col gap-8">
        <div class="weight-600">
            Welcome back {{ user.Name }}
        </div>

        <div class="flex-col gap-8">
            <div class="flex-col">
                <label>Service</label>
                <select v-model="serviceSelected">
                    <option v-for="service in services" :value="service.Id">{{ service.Name }}</option>
                </select>
            </div>

            <div class="flex-col">
                <label>Ammount</label>
                <input type="number" v-model="ammount">
            </div>

            <button @click="addPayment">Add Payment</button>
        </div>

        <div v-if="showPayments">
            Payments:
            <table>
                <thead>
                    <th></th>
                    <th>
                        Service
                    </th>
                    <th>
                        Ammount
                    </th>
                    <th>
                        Date
                    </th>
                    <th></th>
                </thead>
                <tbody>
                    <tr v-for="payment in payments" :key="payment.Id">
                        <td>
                            <input type="checkbox" id="jack" :value="payment.Id" v-model="selectedPayments">
                        </td>
                        <td>
                            {{ payment.ServiceName }}
                        </td>
                        <td>
                            ${{ payment.Ammount }}
                        </td>
                        <td>
                            {{ DateTime.fromISO(payment.Date).toFormat("yyyy-MM-dd HH:mm:ss") }}
                        </td>
                        <td>
                            <button @click="remove(payment.Id)">Remove</button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <button @click="bulkRemove">Bulk Remove</button>
        </div>

    </div>
</template>

<style scoped>
.weight-600 {
    font-weight: 600;
}

.flex-col {
    display: flex;
    flex-direction: column;
}

.gap-8 {
    gap: 8px;
}
</style>