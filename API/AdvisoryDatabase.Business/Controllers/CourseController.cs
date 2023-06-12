using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryDatabase.Business.Controllers
{
    public class CourseController : BaseController
    {
        public APIResponse<Course> GetCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                return SuccessReponse(service.Get(course));
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
            
        }
        public APIResponse<List<Course>> GetAllCourse()
        {
            try
            {
                CourseDataService service = new CourseDataService();
                return SuccessReponse(service.GetAll());
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<List<Course>>(error);
            }
        }
        public APIResponse<Course> InsertCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                course.CourseMasterID = service.Add(course);
                return SuccessReponse(course);
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
        }
        public APIResponse<Course> UpdateCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                CourseSkillMappingService SkillService = new CourseSkillMappingService();
                CourseIndustryMappingService IndustryService = new CourseIndustryMappingService();
                AudienceLevelMappingService audienceLevelService = new AudienceLevelMappingService();
                CourseFieldOfStudyMappingService FOSService = new CourseFieldOfStudyMappingService();
                CourseSGSLSNMappingService SGSLSNService = new CourseSGSLSNMappingService();

                service.Update(course);
                if (course.SkillMasterIDs != null && course.SkillMasterIDs.Any())
                {
                    SkillService.Remove(course.CourseMasterID);
                    foreach (var item in course.SkillMasterIDs)
                    {
                        CourseSkillMapping courseSkillMapping = new CourseSkillMapping();
                        courseSkillMapping.CourseMasterID = course.CourseMasterID;
                        courseSkillMapping.SkillMasterID = (int)item.Id;
                        SkillService.Add(courseSkillMapping);
                    }
                }
                if (course.Industries!=null && course.Industries.Any())
                {
                    IndustryService.Remove(course.CourseMasterID);
                    foreach (var item in course.Industries)
                    {
                        CourseIndustryMapping courseIndustryMapping = new CourseIndustryMapping();
                        courseIndustryMapping.CourseMasterID = course.CourseMasterID;
                        courseIndustryMapping.IndustryID = (int)item.Id;
                        IndustryService.Add(courseIndustryMapping);
                    }
                }
                if (course.AudienceLevels !=null && course.AudienceLevels.Any())
                {
                    audienceLevelService.Remove(course.CourseMasterID);
                    foreach (var item in course.AudienceLevels)
                    {
                        AudienceLevelMapping audienceLevelMapping = new AudienceLevelMapping();
                        audienceLevelMapping.CourseMasterID = course.CourseMasterID;
                        audienceLevelMapping.AudienceLevelId = (int)item.Id;
                        audienceLevelService.Add(audienceLevelMapping);
                    }
                }
                if (course.FieldOfStudyFormGroup != null && course.FieldOfStudyFormGroup.Any())
                {
                    FOSService.Remove(course.CourseMasterID);
                    foreach (var item in course.FieldOfStudyFormGroup)
                    {
                        CourseFieldOfStudyMapping FOSMapping = new CourseFieldOfStudyMapping();
                        FOSMapping.CourseMasterID = course.CourseMasterID;
                        FOSMapping.FieldOfStudyMasterID = (int)item.FieldOfStudy.Id;
                        FOSMapping.FOSCredit = item.FieldOfStudyCredit;
                        FOSService.Add(FOSMapping);
                    }
                }
                if (course.SGSLSNFormGroups !=null && course.SGSLSNFormGroups.Any())
                {
                    SGSLSNService.Remove(course.CourseMasterID);
                    foreach (var item in course.SGSLSNFormGroups)
                    {
                        CourseSGSLSNMapping SGSLSNMapping = new CourseSGSLSNMapping();
                        SGSLSNMapping.CourseMasterID = course.CourseMasterID;
                        SGSLSNMapping.ServiceGroupID = (int)item.ServiceGroup.Id;
                        SGSLSNMapping.ServiceLineID = (int)item.ServiceLine.Id;
                        SGSLSNMapping.ServiceNetworkID = (int)item.ServiceNetwork.Id;
                        SGSLSNService.Add(SGSLSNMapping);
                    }
                }

                return SuccessReponse(course);
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
        }
        public APIResponse<string> DeleteCourse(int CourseMasterID)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                service.Remove(CourseMasterID);
                return SuccessReponse("Success");
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<string>(error);
            }
        }
    }
}
