using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Rzproekt.Core;
using Rzproekt.Core.Consts;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    public class StatisticService : StatisticBase {
        ApplicationDbContext _db;

        public StatisticService(ApplicationDbContext db) => _db = db;
       
        /// <summary>
        /// Метод получает все данные статистики.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable> GetStatisticInfo() {
            return await _db.Statistic.ToListAsync();
        }

        /// <summary>
        /// Метод изменяет статистику.
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public async override Task ChangeStatistic(object stat) {
            try {
                // TODO: Все сделано так, потому что фронт отказался следовать нормальным практикам и пришлось хардкодно изменять данные)
                var json = JsonSerializer.Serialize(stat);
                JObject jsonObject = JObject.Parse(json);
                var aNumber_1 = Convert.ToInt32(jsonObject["nOne"].ToString());
                var aNumber_2 = Convert.ToInt32(jsonObject["nTwo"].ToString());
                var aNumber_3 = Convert.ToInt32(jsonObject["nThree"].ToString());
                var sText_1 = jsonObject["sOne"].ToString();
                var sText_2 = jsonObject["sTwo"].ToString();
                var sText_3 = jsonObject["sThree"].ToString();

                StatisticDto statisticDto = new StatisticDto() { Number = aNumber_1, Text = sText_1, Block = BlockType.STAT };
                StatisticDto statisticDto1 = new StatisticDto() { Number = aNumber_2, Text = sText_2, Block = BlockType.STAT };
                StatisticDto statisticDto2 = new StatisticDto() { Number = aNumber_3, Text = sText_3, Block = BlockType.STAT };

                var aStats = await _db.Statistic.ToListAsync();
                _db.Statistic.RemoveRange(aStats); 

                _db.Statistic.AddRange(statisticDto, statisticDto1, statisticDto2);
                await _db.SaveChangesAsync();
            }

            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
