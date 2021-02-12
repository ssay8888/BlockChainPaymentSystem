using BlockChainPaymentSystem.Constants;
using BlockChainPaymentSystem.Controllers.BlockChain;
using BlockChainPaymentSystem.Models.JsonModels;
using BlockChainPaymentSystem.Net.Packet;
using BlockChainPaymentSystem.Net.Packet.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Net
{
    public class PacketCreator
    {
        public static byte[] SendPong()
        {
            using var packet = new OutPacket();
            packet.Encode<byte>((byte)ClientHeader.Pong);
            return packet.Buffer;
        }

        public static async Task<byte[]> SendChargeResultAsync(ResponsePaymentModel result)
        {
            using var packet = new OutPacket();
            packet.Encode<byte>((byte)ClientHeader.PaymentResult);
            packet.Encode<string>(result.payment_id); 
            packet.Encode<string>(result.payment_status);
            packet.Encode<string>(result.pay_address);
            packet.Encode<string>(result.pay_currency);
            packet.Encode<double>(result.actually_paid);
            packet.Encode<string>(result.order_id);
            packet.Encode<string>(result.outcome_currency);
            packet.Encode<double>(result.outcome_amount);
            packet.Encode<string>(result.created_at.ToString());
            packet.Encode<string>(result.updated_at.ToString());
            var exchange = await PaymentMethod.GetEstimatedPrice(result.outcome_amount, result.pay_currency, "usd");
            var krwstring = double.Parse(PublicMethod.ExchangeRate(exchange.estimated_amount).Replace(",", ""));
            var krw = Math.Round(krwstring / 100d) * 100;
            packet.Encode<string>(krw.ToString());
            packet.Encode<double>(exchange.estimated_amount);
            return packet.Buffer;
        }
    }
}
