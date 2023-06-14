using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace AdvisoryDatabase.Business.Controllers
{
    public class CourseController : BaseController
    {
        public APIResponse<Course> GetCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                return SuccessReponse(service.GetAll(course).SingleOrDefault());
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
                SaveUpdateSkillMasterIDs(course);
                SaveUpdateIndustries(course);
                SaveUpdateAudienceLevels(course);
                SaveUpdateFOSService(course);
                SaveUpdateSGSLSNFormGroups(course);
                SaveUpdateEquivalentCourseIDService(course);
                SaveUpdatePrerequisiteCourseIDService(course);
                SaveUpdateaudienceTypeService(course);
                SaveUpdateCourseFunctionService(course);
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

                service.Update(course);
                SaveUpdateSkillMasterIDs(course);
                SaveUpdateIndustries(course);
                SaveUpdateAudienceLevels(course);
                SaveUpdateFOSService(course);
                SaveUpdateSGSLSNFormGroups(course);
                SaveUpdateEquivalentCourseIDService(course);
                SaveUpdatePrerequisiteCourseIDService(course);
                SaveUpdateaudienceTypeService(course);
                SaveUpdateCourseFunctionService(course);

                return SuccessReponse(course);
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
        }

        private async Task SaveUpdateSkillMasterIDs(Course course)
        {
            CourseSkillMappingService SkillService = new CourseSkillMappingService();
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
        }
        private async Task SaveUpdateIndustries(Course course)
        {
            CourseIndustryMappingService IndustryService = new CourseIndustryMappingService();
            if (course.Industries != null && course.Industries.Any())
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
        }
        private async Task SaveUpdateAudienceLevels(Course course)
        {
            AudienceLevelMappingService audienceLevelService = new AudienceLevelMappingService();
            if (course.AudienceLevels != null && course.AudienceLevels.Any())
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
        }
        private async Task SaveUpdateFOSService(Course course)
        {
            CourseFieldOfStudyMappingService FOSService = new CourseFieldOfStudyMappingService();
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
        }
        private async Task SaveUpdateSGSLSNFormGroups(Course course)
        {
            CourseSGSLSNMappingService SGSLSNService = new CourseSGSLSNMappingService();
            if (course.SGSLSNFormGroups != null && course.SGSLSNFormGroups.Any())
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
        }
        private async Task SaveUpdateEquivalentCourseIDService(Course course)
        {
            EquivalentCourseIDMappingService equivalentCourseIDService = new EquivalentCourseIDMappingService();
            if (course.EquivalentCourseIDFormGroup != null && course.EquivalentCourseIDFormGroup.Any())
            {
                equivalentCourseIDService.Remove(course.CourseMasterID);
                foreach (var item in course.EquivalentCourseIDFormGroup)
                {
                    EquivalentCourseIDMapping equivalentCourseID = new EquivalentCourseIDMapping();
                    equivalentCourseID.CourseMasterID = course.CourseMasterID;
                    equivalentCourseID.EquivalentCourseID = item.EquivalentCourseID;
                    equivalentCourseIDService.Add(equivalentCourseID);
                }
            }
        }
        private async Task SaveUpdatePrerequisiteCourseIDService(Course course)
        {
            PrerequisiteCourseIDMappingService prerequisiteCourseIDService = new PrerequisiteCourseIDMappingService();
            if (course.PrerequisiteCourseIDFormGroup != null && course.PrerequisiteCourseIDFormGroup.Any())
            {
                prerequisiteCourseIDService.Remove(course.CourseMasterID);
                foreach (var item in course.PrerequisiteCourseIDFormGroup)
                {
                    PrerequisiteCourseIDMapping prerequisiteCourseID = new PrerequisiteCourseIDMapping();
                    prerequisiteCourseID.CourseMasterID = course.CourseMasterID;
                    prerequisiteCourseID.PrerequisiteCourseID = item.PrerequisiteCourseID;
                    prerequisiteCourseIDService.Add(prerequisiteCourseID);
                }
            }
        }
        private async Task SaveUpdateaudienceTypeService(Course course)
        {
            AudienceTypeMappingService audienceTypeService = new AudienceTypeMappingService();

            if (course.AudienceTypeFormGroup != null && course.AudienceTypeFormGroup.Any())
            {
                audienceTypeService.Remove(course.CourseMasterID);
                foreach (var item in course.AudienceTypeFormGroup)
                {
                    AudienceTypeMapping audienceType = new AudienceTypeMapping();
                    audienceType.CourseMasterID = course.CourseMasterID;
                    audienceType.AudienceType = item.AudienceType;
                    audienceTypeService.Add(audienceType);
                }
            }
        }
        private async Task SaveUpdateCourseFunctionService(Course course)
        {
            CourseFunctionMasterMappingService courseFunctionService = new CourseFunctionMasterMappingService();

            if (course.FOCUSCourseOwnerFormGroup != null && course.FOCUSCourseOwnerFormGroup.Any())
            {
                courseFunctionService.Remove(course.CourseMasterID);
                foreach (var item in course.FOCUSCourseOwnerFormGroup)
                {
                    CourseFunctionMapping functionMapping = new CourseFunctionMapping();
                    functionMapping.CourseMasterID = course.CourseMasterID;
                    functionMapping.FunctionMasterID = (int)item.Id;
                    courseFunctionService.Add(functionMapping);
                }
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
